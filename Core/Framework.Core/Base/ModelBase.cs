using System;

namespace Framework.Core.Base
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {

        }

        public ViewModes ViewMode { get; set; } = ViewModes.View;

        public SaveModes SaveModes { get; set; } = SaveModes.Submit;
        public bool Spinner { get; set; }

        public Guid CurrentUserId { get; set; }

        public string Comment { get; set; }

        public int? StatusId { get; set; }



    }
    public class LookupViewModelBase : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Text => Name;
    
    }
    public class ViewModelBaseWithLookup<T> : ViewModelBase
    {
        public T Id { get; set; }
    }
    public class ViewModelBase<T> : ViewModelBase
    {
        public T Id { get; set; }
    }
}
