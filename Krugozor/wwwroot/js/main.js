function scrollToElement(){
    var element = document.getElementById("contact");
    element.scrollIntoView({ behavior: 'smooth' });
}
$(document).ready(function () {
    $('#send-form').submit(function (event) {
        event.preventDefault(); // Предотвращаем стандартное поведение формы

        // Скрываем кнопку отправки сразу после нажатия
        $('#submit-button').hide();

        // Сериализуем данные формы
        var formData = $(this).serialize();

        // Отправляем AJAX-запрос на сервер
        $.ajax({
            url: '/Mail/SendMessage',
            method: 'POST',
            data: formData,
            success: function (response) {
                // Выводим результат на странице
                $('#message-result').html(response);
            },
            error: function () {
                // Выводим сообщение об ошибке
                $('#message-result').html('Произошла ошибка при отправке сообщения.');
            }
        });
    });
});
