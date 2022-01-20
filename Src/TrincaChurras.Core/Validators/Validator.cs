using FluentValidation;
using System.Collections.Generic;

namespace TrincaChurras.Core.Validators
{
    public abstract class Validator
    {
        public Validator()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> _notifications;

        protected void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }

        protected void Validate<TValidator, TEntity>(TValidator validator, TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            var validationResult = validator.Validate(entity);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    AddNotification(error.ErrorMessage);
                }
            }
        }

        protected bool IsValid()
        {
            return _notifications.Count == 0;
        }
    }
}
