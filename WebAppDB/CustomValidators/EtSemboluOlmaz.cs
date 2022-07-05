using System.ComponentModel.DataAnnotations;

namespace WebAppDB.CustomValidators
{
    public class EtSemboluOlmaz:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            bool sonuc = false;
            if (value != null)
            {

                sonuc = !value.ToString().Contains("@");
            }

            return sonuc;
        }
    }
}
