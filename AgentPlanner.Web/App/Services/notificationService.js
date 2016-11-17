angular.module('agent_planner').service('notificationService', ['Notification', 'SweetAlert', function (notification, sweetAlert) {
    var defaultTitle = 'Agent planner';
    return {
        success: function (message, title) {
            if (title == undefined) {
                title = defaultTitle;
            }
            notification.success({ message: message, title: title });
        },
        error: function (message, title) {
            if (title == undefined) {
                title = defaultTitle;
            }
            notification.error({ message: message, title: title });
        },
        showConfirmationDialog: function (title, text, type, onConfirm, onCancel) {
            sweetAlert.swal({
                title: title,
                text: text,
                type: type,
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                cancelButtonText: "Cancel",
                closeOnConfirm: true,
                closeOnCancel: true
            }, function (isConfirm) {
                if (isConfirm && onConfirm) {
                    onConfirm();
                } else if (onCancel) {
                    onCancel();
                }
            });
        }
    };
}
]);