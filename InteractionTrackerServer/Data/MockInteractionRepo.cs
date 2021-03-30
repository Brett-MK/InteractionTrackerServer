using InteractionTrackerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Data
{
    public class MockInteractionRepo : IInteractionRepo
    {
        private List<Interaction> _interactions = new List<Interaction>()
                {
                    new Interaction()
                        {
                            CallId = "asd3ad3w90d",
                            Timestamp = DateTime.Parse("2020-08-23T15:10:47.750079"),
                            Duration  = new Duration() {
                                Value = 5,
                                Unit = Unit.Minutes
                            },
                            WaitingTime = new WaitingTime() {
                                Value = 1450,
                                Unit = Unit.Milliseconds
                            },
	                        AgentData = new AgentData() {
		                        AgentId = "49nvfos95a",
		                        AgentName = "Jane",
		                        AgentEmail = "jane@johndoecc.com"

                            },
	                        CallData = new CallData() {
                                CallerName = "Trevor Borskov",
		                        CallerNumber = "+10010020003",
		                        CcNumber = "+19876543210",
		                        Direction = Direction.Inbound
	                        },
                            IssueStatus = IssueStatus.Resolved,
	                        CustomerStatus = CustomerStatus.VIP
                        },
                    new Interaction()
                        {
                            CallId = "asd3ad3w90d",
                            Timestamp = DateTime.Parse("2020-08-23T15:10:47.750079"),
                            Duration  = new Duration() {
                                Value = 5,
                                Unit = Unit.Minutes
                            },
                            WaitingTime = new WaitingTime() {
                                Value = 1450,
                                Unit = Unit.Milliseconds
                            },
                            AgentData = new AgentData() {
                                AgentId = "49nvfos95a",
                                AgentName = "Jane",
                                AgentEmail = "jane@johndoecc.com"

                            },
                            CallData = new CallData() {
                                CallerName = "Trevor Borskov",
                                CallerNumber = "+10010020003",
                                CcNumber = "+19876543210",
                                Direction = Direction.Inbound
                            },
                            IssueStatus = IssueStatus.Resolved,
                            CustomerStatus = CustomerStatus.VIP
                        },
                    new Interaction()
                        {
                            CallId = "asd3ad3w90d",
                            Timestamp = DateTime.Parse("2020-08-23T15:10:47.750079"),
                            Duration  = new Duration() {
                                Value = 5,
                                Unit = Unit.Minutes
                            },
                            WaitingTime = new WaitingTime() {
                                Value = 1450,
                                Unit = Unit.Milliseconds
                            },
                            AgentData = new AgentData() {
                                AgentId = "49nvfos95a",
                                AgentName = "Jane",
                                AgentEmail = "jane@johndoecc.com"

                            },
                            CallData = new CallData() {
                                CallerName = "Trevor Borskov",
                                CallerNumber = "+10010020003",
                                CcNumber = "+19876543210",
                                Direction = Direction.Inbound
                            },
                            IssueStatus = IssueStatus.Resolved,
                            CustomerStatus = CustomerStatus.VIP
                        },
                    new Interaction()
                        {
                            CallId = "asd3ad3w90d",
                            Timestamp = DateTime.Parse("2020-08-23T15:10:47.750079"),
                            Duration  = new Duration() {
                                Value = 5,
                                Unit = Unit.Minutes
                            },
                            WaitingTime = new WaitingTime() {
                                Value = 1450,
                                Unit = Unit.Milliseconds
                            },
                            AgentData = new AgentData() {
                                AgentId = "49nvfos95a",
                                AgentName = "Jane",
                                AgentEmail = "jane@johndoecc.com"

                            },
                            CallData = new CallData() {
                                CallerName = "Trevor Borskov",
                                CallerNumber = "+10010020003",
                                CcNumber = "+19876543210",
                                Direction = Direction.Inbound
                            },
                            IssueStatus = IssueStatus.Resolved,
                            CustomerStatus = CustomerStatus.VIP
                        },
                };

        public void CreateInteraction(Interaction interaction)
        {
            _interactions.Add(interaction);
        }

        public IQueryable<Interaction> GetAllInteractions()
        {
            return _interactions.AsQueryable();
        }

        public Task<Interaction> GetInteractionById(string id)
        {
            return Task.FromResult(_interactions.FirstOrDefault(i => i.CallId == id));
        }

        public Task<bool> SaveChanges()
        {
            // do nothing
            return Task.FromResult(true);
        }
    }
}
