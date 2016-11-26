using System;
using System.Collections.Generic;
using AgentPlanner.Entities.Client;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public Client GetClient(int clientId)
        {
            return _clientRepository.Get(clientId).ToDto();
        }

        public int AddClient(Client client)
        {
            var clientCode = client.ClientCode.ToUpper();

            if(_clientRepository.IsCodeExisting(clientCode)) throw new ClientCodeDuplicateException();

            client.ClientCode = clientCode;

            return _clientRepository.Add(client.ToDbo());
        }

        public int UpdateClient(int clientId, Client client)
        {
            client.Id = clientId;

            var newClientCode = client.ClientCode.ToUpper();

            var dbClient = _clientRepository.Get(clientId);

            if (!dbClient.ClientCode.Equals(newClientCode))
            {
                if (_clientRepository.IsCodeExisting(newClientCode)) throw new ClientCodeDuplicateException();

                client.ClientCode = newClientCode;
            }
            
            return _clientRepository.Update(client.ToDbo());
        }

        public int DeleteClient(int clientId)
        {
            return _clientRepository.Remove(clientId);
        }


        public Client[] GetPaginatedClients(int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            return _clientRepository.GetClients(pageSize, resultsToSkip).ToDtos();
        }

        public Client[] SearchClient(string searchTerm)
        {
            return _clientRepository.SearchTerm(searchTerm).ToDtos();
        }

        public Client[] GetAll(int[] clientIds)
        {
            return _clientRepository.GetAll(clientIds).ToDtos();
        }

        public int GetTotalClientsCount()
        {
            return _clientRepository.Count();
        }

        public bool CheckCheckCode(string code)
        {
            return _clientRepository.IsCodeExisting(code?.ToUpper());
        }
    }
}