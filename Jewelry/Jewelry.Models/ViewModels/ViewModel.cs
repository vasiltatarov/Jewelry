namespace Jewelry.Models.ViewModels;

using System.ComponentModel;

public abstract class ViewModel
{
    public virtual string GetDescription(Type type, string value)
    {
        return ((DescriptionAttribute)(type.GetMember(value)[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0])).Description;
    }
}
