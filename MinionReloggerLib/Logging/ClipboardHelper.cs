using System.Windows.Forms;

namespace MinionReloggerLib.Logging
{
    public class ClipboardHelper : STAHelper
    {
        private readonly object _data;
        private readonly string _format;

        internal ClipboardHelper(string format, object data)
        {
            _format = format;
            _data = data;
        }

        protected override void Work()
        {
            var obj = new DataObject(
                _format,
                _data
                );

            Clipboard.SetDataObject(obj, true);
        }
    }
}