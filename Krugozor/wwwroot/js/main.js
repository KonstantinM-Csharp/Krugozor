function scrollToElement(){
    var element = document.getElementById("contact");
    element.scrollIntoView({ behavior: 'smooth' });
}
function downloadFile() {
    const link = document.createElement('a');
    link.href = '/files/krugozor.pdf'; // Укажите путь к файлу
    link.download = 'Krugozor-CartPartner.pdf'; // Укажите имя файла, которое будет при скачивании
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
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
