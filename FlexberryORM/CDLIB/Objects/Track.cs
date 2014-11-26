﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.CDLIB
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Track.
    /// </summary>
    // *** Start programmer edit section *** (Track CustomAttributes)

    // *** End programmer edit section *** (Track CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("Track_E", new string[] {
            "Name",
            "Length",
            "Author.FirstName",
            "Singer.FirstName"})]
    public class Track : ICSSoft.STORMNET.DataObject
    {
        
        private string fName;
        
        private int fLength;
        
        private IIS.CDLIB.Person fAuthor;
        
        private IIS.CDLIB.Person fSinger;
        
        private IIS.CDLIB.CDDA fCDDA;
        
        // *** Start programmer edit section *** (Track CustomMembers)

        // *** End programmer edit section *** (Track CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (Track.Name CustomAttributes)

        // *** End programmer edit section *** (Track.Name CustomAttributes)
        [StrLen(255)]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (Track.Name Get start)

                // *** End programmer edit section *** (Track.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (Track.Name Get end)

                // *** End programmer edit section *** (Track.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Track.Name Set start)

                // *** End programmer edit section *** (Track.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (Track.Name Set end)

                // *** End programmer edit section *** (Track.Name Set end)
            }
        }
        
        /// <summary>
        /// Length.
        /// </summary>
        // *** Start programmer edit section *** (Track.Length CustomAttributes)

        // *** End programmer edit section *** (Track.Length CustomAttributes)
        public virtual int Length
        {
            get
            {
                // *** Start programmer edit section *** (Track.Length Get start)

                // *** End programmer edit section *** (Track.Length Get start)
                int result = this.fLength;
                // *** Start programmer edit section *** (Track.Length Get end)

                // *** End programmer edit section *** (Track.Length Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Track.Length Set start)

                // *** End programmer edit section *** (Track.Length Set start)
                this.fLength = value;
                // *** Start programmer edit section *** (Track.Length Set end)

                // *** End programmer edit section *** (Track.Length Set end)
            }
        }
        
        /// <summary>
        /// Track.
        /// </summary>
        // *** Start programmer edit section *** (Track.Author CustomAttributes)

        // *** End programmer edit section *** (Track.Author CustomAttributes)
        [PropertyStorage(new string[] {
                "Author"})]
        [NotNull()]
        public virtual IIS.CDLIB.Person Author
        {
            get
            {
                // *** Start programmer edit section *** (Track.Author Get start)

                // *** End programmer edit section *** (Track.Author Get start)
                IIS.CDLIB.Person result = this.fAuthor;
                // *** Start programmer edit section *** (Track.Author Get end)

                // *** End programmer edit section *** (Track.Author Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Track.Author Set start)

                // *** End programmer edit section *** (Track.Author Set start)
                this.fAuthor = value;
                // *** Start programmer edit section *** (Track.Author Set end)

                // *** End programmer edit section *** (Track.Author Set end)
            }
        }
        
        /// <summary>
        /// Track.
        /// </summary>
        // *** Start programmer edit section *** (Track.Singer CustomAttributes)

        // *** End programmer edit section *** (Track.Singer CustomAttributes)
        [PropertyStorage(new string[] {
                "Singer"})]
        public virtual IIS.CDLIB.Person Singer
        {
            get
            {
                // *** Start programmer edit section *** (Track.Singer Get start)

                // *** End programmer edit section *** (Track.Singer Get start)
                IIS.CDLIB.Person result = this.fSinger;
                // *** Start programmer edit section *** (Track.Singer Get end)

                // *** End programmer edit section *** (Track.Singer Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Track.Singer Set start)

                // *** End programmer edit section *** (Track.Singer Set start)
                this.fSinger = value;
                // *** Start programmer edit section *** (Track.Singer Set end)

                // *** End programmer edit section *** (Track.Singer Set end)
            }
        }
        
        /// <summary>
        /// мастеровая ссылка на шапку IIS.CDLIB.CDDA.
        /// </summary>
        // *** Start programmer edit section *** (Track.CDDA CustomAttributes)

        // *** End programmer edit section *** (Track.CDDA CustomAttributes)
        [Agregator()]
        [NotNull()]
        [PropertyStorage(new string[] {
                "CDDA"})]
        public virtual IIS.CDLIB.CDDA CDDA
        {
            get
            {
                // *** Start programmer edit section *** (Track.CDDA Get start)

                // *** End programmer edit section *** (Track.CDDA Get start)
                IIS.CDLIB.CDDA result = this.fCDDA;
                // *** Start programmer edit section *** (Track.CDDA Get end)

                // *** End programmer edit section *** (Track.CDDA Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Track.CDDA Set start)

                // *** End programmer edit section *** (Track.CDDA Set start)
                this.fCDDA = value;
                // *** Start programmer edit section *** (Track.CDDA Set end)

                // *** End programmer edit section *** (Track.CDDA Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "Track_E" view.
            /// </summary>
            public static ICSSoft.STORMNET.View Track_E
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("Track_E", typeof(IIS.CDLIB.Track));
                }
            }
        }
    }
    
    /// <summary>
    /// Detail array of Track.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfTrack CustomAttributes)

    // *** End programmer edit section *** (DetailArrayDetailArrayOfTrack CustomAttributes)
    public class DetailArrayOfTrack : ICSSoft.STORMNET.DetailArray
    {
        
        // *** Start programmer edit section *** (IIS.CDLIB.DetailArrayOfTrack members)

        // *** End programmer edit section *** (IIS.CDLIB.DetailArrayOfTrack members)

        
        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type Track by index.
        /// </summary>
        /// <summary>
        /// Adds object with type Track.
        /// </summary>
        public DetailArrayOfTrack(IIS.CDLIB.CDDA fCDDA) : 
                base(typeof(Track), ((ICSSoft.STORMNET.DataObject)(fCDDA)))
        {
        }
        
        public IIS.CDLIB.Track this[int index]
        {
            get
            {
                return ((IIS.CDLIB.Track)(this.ItemByIndex(index)));
            }
        }
        
        public virtual void Add(IIS.CDLIB.Track dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}