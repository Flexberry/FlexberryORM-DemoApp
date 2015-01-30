namespace NewPlatform.Flexberry.Samples
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sample object model.
    /// </summary>
    public class SampleData
    {
        /// <summary>
        /// Sample caption for tree.
        /// </summary>
        public string SampleCaption { get; set; }

        /// <summary>
        /// The wiki url for this sample.
        /// </summary>
        public string WikiUrl { get; set; }

        /// <summary>
        /// Sample task log.
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// Action for running.
        /// </summary>
        public Action SampleAction { get; set; }

        /// <summary>
        /// Child nodes list.
        /// </summary>
        public List<SampleData> ChildNodesList { get; set; }
    }
}
