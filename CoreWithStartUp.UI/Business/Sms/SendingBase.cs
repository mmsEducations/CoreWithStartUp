namespace CoreWithStartUp.UI.Business
{
    public class SendingBase
    {
        public string Header { get; set; }

        public string Content { get; set; }

        public string Sender { get; set; } = "System";

        public string Receiver { get; set; }

        public DateTime SendingDate { get; set; } = new DateTime();
    }
}