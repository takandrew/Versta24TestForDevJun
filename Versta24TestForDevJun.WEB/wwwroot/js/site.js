$('#modalShow').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget); // Кнопка, которая открыла модальное окно
    let itemId = button.data('item-id'); // Получение идентификатора заказа из атрибута data-item-id

    // AJAX-запрос на сервер для получения данных о заказе
    $.ajax({
        url: 'Home/Index/' + itemId,
        type: 'GET',
        success: function (data) {
            // Обновление содержимого модального окна с полученными данными
            let modal = $('#modalShow');
            modal.find('.modal-title').text('Заказ №' + data.id);
            modal.find('.modal-body').empty();

            let Id = "senderCity"
            let label = $('<label>').attr('for', Id).text("Город отправителя");
            let input = $('<input>').attr({
                id: Id,
                type: 'text',
                readonly: true
            }).val(data.senderCity);

            let div = $('<div>').addClass('form-group');
            div.append(label).append(input);

            modal.find('.modal-body').append(div);

            Id = "senderAddres"
            label = $('<label>').attr('for', Id).text("Адрес отправителя");
            input = $('<input>').attr({
                id: Id,
                type: 'text',
                readonly: true
            }).val(data.senderAddress);

            div = $('<div>').addClass('form-group');
            div.append(label).append(input);

            modal.find('.modal-body').append(div);

            Id = "recipientCity"
            label = $('<label>').attr('for', Id).text("Город получателя");
            input = $('<input>').attr({
                id: Id,
                type: 'text',
                readonly: true
            }).val(data.recipientCity);

            div = $('<div>').addClass('form-group');
            div.append(label).append(input);

            modal.find('.modal-body').append(div);

            Id = "recipientAddress"
            label = $('<label>').attr('for', Id).text("Адрес получателя");
            input = $('<input>').attr({
                id: Id,
                type: 'text',
                readonly: true
            }).val(data.recipientAddress);

            div = $('<div>').addClass('form-group');
            div.append(label).append(input);

            modal.find('.modal-body').append(div);

            Id = "cargoWeight"
            label = $('<label>').attr('for', Id).text("Вес груза, (г)");
            input = $('<input>').attr({
                id: Id,
                type: 'number',
                readonly: true
            }).val(data.cargoWeight.toFixed(2));

            div = $('<div>').addClass('form-group');
            div.append(label).append(input);

            modal.find('.modal-body').append(div);

            Id = "cargoPickUpDate"
            label = $('<label>').attr('for', Id).text("Дата забора груза");
            input = $('<input>').attr({
                id: Id,
                type: 'date',
                readonly: true
            }).val(data.cargoPickUpDate);

            div = $('<div>').addClass('form-group');
            div.append(label).append(input);

            modal.find('.modal-body').append(div);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('Ошибка AJAX:', errorThrown);
        }
    });
});


$('#formCreateOrder').submit(function (event) {
    // Отменить стандартное поведение формы (перезагрузка страницы)
    event.preventDefault();

    // Получить данные формы
    var dataObject = {};

    $(this).serializeArray().forEach(function (item) {
        dataObject[item.name] = item.value;
    });
    
    // Выполнить AJAX-запрос
    $.ajax({
        url: 'Home/CreateOrder',
        method: 'POST',
        data: JSON.stringify(dataObject),
        contentType: 'application/json',
        success: function (response) {
            location.reload();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('Ошибка AJAX:', errorThrown);
        }
    });
});