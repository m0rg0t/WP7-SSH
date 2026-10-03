namespace System.Windows { public class RoutedEventArgs : System.EventArgs {} public static class MessageBox { public static void Show(string s) {} } }
namespace System.Windows.Controls { public class ValidationErrorEventArgs : System.EventArgs {} }
namespace System.Windows.Documents { class Marker {} }
namespace System.Windows.Input { public class GestureEventArgs : System.EventArgs {} public class ManipulationStartedEventArgs : System.EventArgs {} public class ManipulationCompletedEventArgs : System.EventArgs {} }
namespace System.Windows.Media { class Marker {} }
namespace System.Windows.Media.Animation { class Marker {} }
namespace System.Windows.Shapes { class Marker {} }
namespace Microsoft.Phone.Controls { public class PhoneApplicationPage {} }
namespace m0rg0t_SSH { public partial class MainPage {public TextBox CommandOutput=new TextBox();public TextBox Commandline=new TextBox();void InitializeComponent(){} } public class TextBox {public string Text="";} public delegate void DownloadStringCompletedEventHandler(object sender, DownloadStringCompletedEventArgs e); public class DownloadStringCompletedEventArgs : System.EventArgs {public string Result; } public class WebClient {public static System.Uri LastUri;public static bool SubscribedBeforeStart;public event DownloadStringCompletedEventHandler DownloadStringCompleted;public void DownloadStringAsync(System.Uri u) {LastUri=u;SubscribedBeforeStart=DownloadStringCompleted!=null;} } }
