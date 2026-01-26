using AutoManage.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AutoManage.API.Filters
{
    public class DomainNotificationFilter : IActionFilter
    {
        private readonly IDomainNotificationHandler _notifications;

        public DomainNotificationFilter(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Não faz nada antes da requisição ser executada
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_notifications.HasNotifications())
                return;

            context.Result = new BadRequestObjectResult(new
            {
                success = false,
                errors = _notifications
                    .GetNotifications()
                    .Select(n => new { n.Key, n.Message })
            });
        }
    }
}
