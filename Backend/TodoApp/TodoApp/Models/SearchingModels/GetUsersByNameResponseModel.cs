using System.Collections.Generic;

namespace TodoApp.Models.SearchingModels
{
    public class GetUsersByNameResponseModel
    {
        public GetUsersByNameResponseModel(IEnumerable<GetUsersByNameItemResponseModel> users)
        {
            Users = users;
        }

        public IEnumerable<GetUsersByNameItemResponseModel> Users { get; }
    }
}