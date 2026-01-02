/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class TimeRange : Context, IContext
    {
        public TimeRange(string startTime, string endTime, object? id = null, string? name = null)
            : base(ContextTypes.TimeRange, id, name)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
