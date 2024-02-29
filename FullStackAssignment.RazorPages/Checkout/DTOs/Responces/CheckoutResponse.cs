namespace Checkout.DTOs.Responces
{
    public class CheckoutResponse
    {
        public Status Status { get; set; }
        public string ErrorMessage { get; set; }

        public static CheckoutResponse Failure(string message = null)
        {
            return new CheckoutResponse { Status = Status.Failure, ErrorMessage = message };
        }

        public static CheckoutResponse Success(string message = null)
        {
            return new CheckoutResponse { Status = Status.Success, ErrorMessage = message };
        }
    }

    public enum Status { Success, Failure };
}
