function scrollToElement(){
    var element = document.getElementById("contact");
    element.scrollIntoView({ behavior: 'smooth' });
}
function downloadFile() {
    const link = document.createElement('a');
    link.href = '/files/krugozor.pdf'; // ������� ���� � �����
    link.download = 'Krugozor-CartPartner.pdf'; // ������� ��� �����, ������� ����� ��� ����������
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
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
