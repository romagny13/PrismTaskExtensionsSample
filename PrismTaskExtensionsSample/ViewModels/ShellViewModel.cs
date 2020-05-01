using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismTaskExtensionsSample.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private bool isBusy;
        private string message;
        private bool throwException;
        private DelegateCommand doWorkCommand;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public bool ThrowException
        {
            get { return throwException; }
            set { SetProperty(ref throwException , value); }
        }

        public DelegateCommand DoWorkCommand
        {
            get
            {
                if (doWorkCommand == null)
                    doWorkCommand = new DelegateCommand(ExecuteDoWorkCommand);
                return doWorkCommand;
            }
        }

        private void ExecuteDoWorkCommand()
        {
            DoWork().Await(OnCompeted, OnError);
        }

        private void OnError(Exception ex)
        {
            Message = $"Error: {ex.Message}";
        }

        private void OnCompeted()
        {
            Message += "... Task completed";
        }

        private async Task DoWork()
        {
            IsBusy = true;
            Message = "Starting work ...";

            await Task.Delay(5000);

            IsBusy = false;

            if (throwException)
                throw new Exception("Exception handled");
            else
                Message = "Work completed";

        }
    }
}
