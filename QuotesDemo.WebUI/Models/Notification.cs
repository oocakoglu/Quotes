using Newtonsoft.Json;

namespace QuotesDemo.WebUI.Models
{
    public class Notification
    {
        public string Message { get; set; }
        public string MessageType { get; set; }


        public Notification(mType mtype, string _message)
        {
            this.Message = _message;
            if (mtype == mType.Success)
                MessageType = "success";
            else if (mtype == mType.Danger)
                MessageType = "danger";
            else if (mtype == mType.Info)
                MessageType = "info";
            else
                MessageType = "warning";
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }


    public enum mType
    {
        Success,
        Danger,
        Info,
        Warning
    }
}
