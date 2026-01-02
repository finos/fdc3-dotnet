/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3;
using Finos.Fdc3.Context;
using Finos.Fdc3.NewtonsoftJson.Serialization;
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
                        if (_listener != null)
                        {
                            await _listener.Unsubscribe();
                        }

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
