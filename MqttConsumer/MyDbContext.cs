using Microsoft.EntityFrameworkCore;
using MqttConsumer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MqttConsumer
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<ConsumerData> ConsumerDatas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MyConsumerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsumerData>(entity =>
            entity.HasKey(e => e.Id));
        }
    }
}
