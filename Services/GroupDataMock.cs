using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using CoreServiceDevReference;

namespace PARiConnect.MVCApp.Services
{
    public class GroupDataMock : IGroupData
    {
        List<Group> _groups;
        public GroupDataMock()
        {
            _groups = new List<Group>
            {
                new Group {
                    ClientGroupKey = 55,
                    Name ="Group 11"
                }
            };
        }

        public Task<IEnumerable<Group>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientGroup> GetByKeyAsync(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Group>> GetListAsync()
        {
            return await Task.Run(() => _groups);
        }

        public Task<ClientGroup> SaveOrUpdate(ClientGroup clientGroup)
        {
            //var group = new Group();
            //if (group.GroupId > 0)

            //_groups.Add(new Group(clientGroup));
             throw new NotImplementedException();
        }
    }
}

