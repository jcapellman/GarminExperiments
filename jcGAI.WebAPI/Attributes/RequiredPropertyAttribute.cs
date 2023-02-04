using System.ComponentModel.DataAnnotations;

namespace jcGAI.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredPropertyAttribute : ValidationAttribute
    {
        private Type? _propertyType;

        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return false;
            }

            _propertyType = value.GetType();

            if (_propertyType == typeof(Guid))
            {
                return Guid.TryParse(value.ToString(), out Guid _);
            } else if (_propertyType == typeof(string))
            {
                return string.IsNullOrEmpty(value.ToString());
            }
            
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            _propertyType ??= GetType();

            return $"{name} must be of type {_propertyType.Name}";
        }
    }
}