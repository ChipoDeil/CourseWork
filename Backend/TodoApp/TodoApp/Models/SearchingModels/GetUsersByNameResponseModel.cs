using System.Collections.Generic;

namespace TodoApp.Models.SearchingModels
{
    public class GetUsersByNameResponseModel
    {
        public IEnumerable<GetUsersByNameItemResponseModel> Users { get; }

        public GetUsersByNameResponseModel(IEnumerable<GetUsersByNameItemResponseModel> users)
        {
            Users = users;
        }
    }
}
