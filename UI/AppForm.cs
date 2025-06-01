using System.Windows.Forms;
using Service;

namespace UI
{
    public partial class AppForm : Form
    {
        protected internal IAppService AppService;
    
        public AppForm() : this(null) { }

        public AppForm(IAppService appService = null)
        {
            AppService = appService;
        }
    }
}