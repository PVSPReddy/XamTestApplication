using System;

using Xamarin.Forms;

namespace PlainShellPOC.Helpers
{
    public static class AppExceptionHandler
    {
        public static void ExceptionLogger(Exception exception)
        {
            try
            {
                var msg = exception.Message + "\n" + exception.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}

