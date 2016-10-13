using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FormsPlugin.Iconize;
using Plugin.Iconize;
using Xamarin.Forms;

namespace Iconize.FormsSample
{
    public class ModuleWrapper : INotifyPropertyChanged
    {
        #region Commands

        private Command _modalTestCommand;
        public ICommand ModalTestCommand => _modalTestCommand ?? (_modalTestCommand = new Command(ExecuteModalTest));

        private Command _visibleTestCommand;
        public ICommand VisibleTestCommand => _visibleTestCommand ?? (_visibleTestCommand = new Command(ExecuteVisibleTest));

        #endregion Commands

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Members

        private IIconModule _module;

        #endregion Members

        #region Properties

        public ICollection<IIcon> Characters => _module.Characters;

        public String FontFamily => _module.FontFamily;

        private Boolean _visibleTest;
        public Boolean VisibleTest
        {
            get
            {
                return _visibleTest;
            }
            set
            {
                _visibleTest = value;
                NotifyPropertyChanged();
            }
        }

        #endregion Properties

        public ModuleWrapper(IIconModule module)
        {
            _module = module;
        }

        public void ExecuteModalTest()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new IconNavigationPage(new Page1 { BindingContext = this }));
        }

        public void ExecuteVisibleTest()
        {
            VisibleTest = !VisibleTest;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "") => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);
    }
}