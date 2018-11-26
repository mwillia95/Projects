using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace AU_ACM_Site.Models.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            this.ToTable("Event");

            this.HasKey(t => t.EventId);
            this.Property(t => t.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("EVENT_ID");
            this.Property(t => t.Title)
                .HasColumnName("TITLE");
            this.Property(t => t.Description)
                .HasColumnName("DESCRIPTION");
            this.Property(t => t.StartTime)
                .HasColumnName("START_TIME");
            this.Property(t => t.EndTime)
                .HasColumnName("END_TIME");
        }
    }
}