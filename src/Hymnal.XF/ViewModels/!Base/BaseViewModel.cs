using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace Hymnal.XF.ViewModels
{
    public abstract class BaseViewModel : BindableBase, IInitialize, IInitializeAsync, INavigationAware, IDestructible, IPageLifecycleAware
    {
        public readonly INavigationService NavigationService;

        #region Properties
        public static INavigationService RootPageNavigationService { get; set; }

        private bool busy = false;
        public bool Busy
        {
            get => busy;
            set
            {
                SetProperty(ref busy, value);
                RaisePropertyChanged(nameof(NotBusy));
            }
        }

        public bool NotBusy => !busy;
        #endregion

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #region Life Cycle
        public virtual void Initialize(INavigationParameters parameters)
        { }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// When navigate from this VM
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        { }

        /// <summary>
        /// When navigate to this VM
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        { }

        /// <summary>
        /// Destroing
        /// </summary>
        public virtual void Destroy()
        { }

        /// <summary>
        /// On Appearing
        /// </summary>
        public virtual void OnAppearing()
        { }

        /// <summary>
        /// On Disappearing
        /// </summary>
        public virtual void OnDisappearing()
        { }
        #endregion
    }
}
