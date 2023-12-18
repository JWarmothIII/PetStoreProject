using System.ComponentModel.DataAnnotations;

namespace PetStore.Components.Pages
{

    public class PaymentModel
    {
        [Required(ErrorMessage = "Card Number is required")]
        [CustomCreditCardValidation(ErrorMessage = "Please enter a valid credit card number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiry Date is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Please enter a valid MM/YY format")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Please enter a valid CVV")]
        public string CVV { get; set; }
    }



    public class CustomCreditCardValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cardNumber = value.ToString().Replace(" ", "");
                if (!IsValidCreditCardNumber(cardNumber))
                {
                    return new ValidationResult(ErrorMessage ?? "Invalid credit card number");
                }
            }

            return ValidationResult.Success;
        }

        private bool IsValidCreditCardNumber(string cardNumber)
        {
            cardNumber = cardNumber.Replace("", "");
            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());
                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = digit % 10 + 1;
                    }
                }
                sum += digit;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }
    }
}