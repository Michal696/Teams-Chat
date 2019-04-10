using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Repositories;

namespace Teams.BL.Tests

{
    public class MessageRepositoryTestsFixture
    {
        private readonly IMessageRepository repository;
        public MessageRepositoryTestsFixture()
        {
            repository = new MessageRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
        }

        public IMessageRepository Repository => repository;
    }
}