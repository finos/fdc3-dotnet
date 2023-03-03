
/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using MorganStanley.Fdc3;
using MorganStanley.Fdc3.Context;
using MorganStanley.Fdc3.Json.Serialization;
using Newtonsoft.Json;
using Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfFdc3.ViewModels
{
    public class WorkbenchViewModel : INotifyPropertyChanged
    {
        private readonly IDesktopAgent _desktopAgent;
        private IListener? _listener;
        private ICommand? _joinChannelCommand;
        private ICommand? _addContextListenerCommand;
        private ICommand? _broadcastContextCommand;
        private Fdc3JsonSerializerSettings SerializerSettings = new Fdc3JsonSerializerSettings() { Formatting = Formatting.Indented };

        public WorkbenchViewModel(IDesktopAgent desktopAgent)
        {
            _desktopAgent = desktopAgent;
        }

        public IImplementationMetadata? ImplementionMetadata
        {
            get { return _desktopAgent?.GetInfo()?.Result; }
        }

        public IEnumerable<IChannel>? AvailableChannels
        {
            get { return _desktopAgent?.GetUserChannels()?.Result; }
        }

        public IChannel? SelectedChannel { get; set; }

        public ICommand JoinChannelCommand
        {
            get
            {
                return _joinChannelCommand ?? (_joinChannelCommand = new DelegateCommand(() =>
                {
                    if (this.SelectedChannel != null)
                    {
                        _desktopAgent.JoinUserChannel(this.SelectedChannel.Id);
                    }
                }));
            }
        }

        public IEnumerable<IContext> AvailableContexts
        {
            get
            {
                return new IContext[]
                {
                    new Contact(new ContactID() {Email="jane.doe@mail.com"}, "Jane Doe"),
                    new Instrument(new InstrumentID() {Ticker = "MSFT", RIC="MSFT.OQ", ISIN="US5949181045"}),
                    new Position(200000, new Instrument(new InstrumentID() {Ticker = "AAPL"}))
                };
            }
        }

        public IContext? SelectedContextListener { get; set; }

        public string? LastContextMessage { get; private set; }

        public ICommand AddContextListenerCommand
        {
             get
            {
                return _addContextListenerCommand ?? (_addContextListenerCommand = new DelegateCommand(async () =>
                {
                    if (this.SelectedContextListener != null)
                    {
                        _listener?.Unsubscribe();

                        _listener = await _desktopAgent.AddContextListener<IContext>(this.SelectedContextListener.Type, (context, contextMetadata) =>
                        {
                            this.LastContextMessage = JsonConvert.SerializeObject(context, this.SerializerSettings);
                            this.OnPropertyChanged("LastContextMessage");
                        });
                    }
                }));
            }
        }

        public IContext? SelectedContext { get; set; }


        public ICommand BroadcastContextCommand
        {
            get
            {
                return _broadcastContextCommand ?? (_broadcastContextCommand = new DelegateCommand(() =>
                {
                    if (this.SelectedContext != null)
                    {
                        _desktopAgent.Broadcast(this.SelectedContext);
                    }
                }));
            }
        }

        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
