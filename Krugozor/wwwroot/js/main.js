function scrollToElement(){
    var element = document.getElementById("contact");
    element.scrollIntoView({ behavior: 'smooth' });
}
$(document).ready(function () {
    $('#send-form').submit(function (event) {
        event.preventDefault(); // ������������� ����������� ��������� �����

        // �������� ������ �������� ����� ����� �������
        $('#submit-button').hide();

        // ����������� ������ �����
        var formData = $(this).serialize();

        // ���������� AJAX-������ �� ������
        $.ajax({
            url: '/Mail/SendMessage',
            method: 'POST',
            data: formData,
            success: function (response) {
                // ������� ��������� �� ��������
                $('#message-result').html(response);
            },
            error: function () {
                // ������� ��������� �� ������
                $('#message-result').html('��������� ������ ��� �������� ���������.');
            }
        });
    });
});
