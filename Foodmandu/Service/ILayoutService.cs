using Foodmandu.Model;

namespace Foodmandu.Service
{
    public interface ILayoutService
    {
        IList<Layouts> GetLayoutDetails();
        IList<LayoutItems> GetLayoutItemDetails(int layoutId);
        IList<LayoutItems> GetLayout_Item_Index_Details();
    }
}
