﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211215140206_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Data.Identity.UserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("IsActive")
                        .HasColumnType("integer");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserImage")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("UserType")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserIdentity");
                });

            modelBuilder.Entity("Api.Domain.Entities.EventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventImage")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<TimeSpan>("EventTime")
                        .HasColumnType("interval");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PeopleAmount")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("EventEntity");
                });

            modelBuilder.Entity("Api.Domain.Entities.ListSocialMediaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SocialMediaName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ListSocialMediaEntity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("835427f0-e8f3-4eba-8fb4-be0f1f62ad66"),
                            SocialMediaName = "Facebook"
                        },
                        new
                        {
                            Id = new Guid("0bb53dfc-edd9-4334-b91d-5f83d7c01790"),
                            SocialMediaName = "Instagram"
                        },
                        new
                        {
                            Id = new Guid("750e0ada-6a8d-40fd-8f1c-f8c568a5f908"),
                            SocialMediaName = "Gettr"
                        },
                        new
                        {
                            Id = new Guid("f300af93-b4c6-40de-8a58-9334c0c68a25"),
                            SocialMediaName = "Telegram"
                        },
                        new
                        {
                            Id = new Guid("d872986f-0b4b-4f2d-90b9-29efdc02d1c4"),
                            SocialMediaName = "WeChat"
                        },
                        new
                        {
                            Id = new Guid("9e97a4f5-7a9d-42df-a2c3-33186255e758"),
                            SocialMediaName = "QZone"
                        },
                        new
                        {
                            Id = new Guid("84e932d0-09ea-4adf-8756-623953d5750c"),
                            SocialMediaName = "Tumblr"
                        },
                        new
                        {
                            Id = new Guid("519cfcf1-5efa-4f64-a778-c6bc09b8ea1d"),
                            SocialMediaName = "Twitter"
                        },
                        new
                        {
                            Id = new Guid("1530bfdf-9c22-416b-9787-ea9f09366af2"),
                            SocialMediaName = "Google+"
                        },
                        new
                        {
                            Id = new Guid("21da8b6c-d49c-448a-aed1-49f29a58411f"),
                            SocialMediaName = "Skype"
                        },
                        new
                        {
                            Id = new Guid("f5935f0e-cdb7-4d91-a912-e057e9d64987"),
                            SocialMediaName = "Viber"
                        },
                        new
                        {
                            Id = new Guid("5a43a259-84b7-4a8f-9706-9ddb3b38f2ad"),
                            SocialMediaName = "line"
                        },
                        new
                        {
                            Id = new Guid("3720e5ed-e5bf-42b6-8a7e-b089fdef01f9"),
                            SocialMediaName = "Sina Weibo"
                        },
                        new
                        {
                            Id = new Guid("07cec255-3f6c-4d5a-8cad-4761ab3f7659"),
                            SocialMediaName = "Snapchat"
                        },
                        new
                        {
                            Id = new Guid("4182ed6c-0fda-4ed4-a5e2-4355d12f4182"),
                            SocialMediaName = "Pinterest"
                        },
                        new
                        {
                            Id = new Guid("1dca59a8-5b12-41fe-8fb7-173c813c1e5e"),
                            SocialMediaName = "LinkedIn"
                        },
                        new
                        {
                            Id = new Guid("b1fd397a-7ff6-40b5-a4e4-9a808c1e523f"),
                            SocialMediaName = "Reddit"
                        },
                        new
                        {
                            Id = new Guid("15d3309c-1536-4e1e-acc0-29298a03c799"),
                            SocialMediaName = "Taringa"
                        },
                        new
                        {
                            Id = new Guid("23ed49af-c2cc-436a-a3d7-4e2835ac9dec"),
                            SocialMediaName = "Foursquare"
                        },
                        new
                        {
                            Id = new Guid("12267324-0996-49fb-986a-78acf7527221"),
                            SocialMediaName = "Badoo"
                        },
                        new
                        {
                            Id = new Guid("5800ce15-ebe5-4903-9010-db00d9c6486a"),
                            SocialMediaName = "Myspace"
                        },
                        new
                        {
                            Id = new Guid("0f2e4538-c295-485c-9b6e-0e197ba0f8f2"),
                            SocialMediaName = "YouTube"
                        },
                        new
                        {
                            Id = new Guid("3ddb80fe-c9a8-49c6-9fb6-d0011c15ceca"),
                            SocialMediaName = "Upstream"
                        },
                        new
                        {
                            Id = new Guid("f54bfbc0-af0a-44ec-8c80-83f7f2976a90"),
                            SocialMediaName = "MeetMe"
                        },
                        new
                        {
                            Id = new Guid("c89a7270-ffa5-4822-9b95-f88b788e1fc5"),
                            SocialMediaName = "Vero"
                        },
                        new
                        {
                            Id = new Guid("0a96c1f3-f59f-4ade-be30-1e173420801c"),
                            SocialMediaName = "TikTok"
                        },
                        new
                        {
                            Id = new Guid("d7daebf4-7d12-4bdd-968f-4d15e40606d3"),
                            SocialMediaName = "WT Social"
                        },
                        new
                        {
                            Id = new Guid("09188b13-b2a2-4758-83b7-db033cf24287"),
                            SocialMediaName = "Caffeine"
                        },
                        new
                        {
                            Id = new Guid("1c975d64-b90d-4be5-8fe1-0d03b5666b10"),
                            SocialMediaName = "italki"
                        },
                        new
                        {
                            Id = new Guid("5f81856f-e4b9-4160-b665-6985a0e2fa13"),
                            SocialMediaName = "Vimeo"
                        },
                        new
                        {
                            Id = new Guid("e38c3125-5535-4f44-8038-18f91635444a"),
                            SocialMediaName = "Gab"
                        },
                        new
                        {
                            Id = new Guid("83cd3309-9727-4238-8d68-1bfa39f5705b"),
                            SocialMediaName = "Rumble"
                        },
                        new
                        {
                            Id = new Guid("33edbe6b-ab83-4268-b2a8-a40e0d233259"),
                            SocialMediaName = "Parler"
                        },
                        new
                        {
                            Id = new Guid("29a36971-5b6d-4e9b-9abb-f446b496d4fe"),
                            SocialMediaName = "Odysee"
                        },
                        new
                        {
                            Id = new Guid("a0933bc7-8443-416e-aac0-763191dd1011"),
                            SocialMediaName = "Github"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.LotEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LotName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("Api.Domain.Entities.SocialMediaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("SocialMedia")
                        .HasColumnType("text");

                    b.Property<Guid?>("SpeakerId")
                        .HasColumnType("uuid");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("Api.Domain.Entities.SpeakerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiniResume")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("SpeakerEmail")
                        .HasColumnType("text");

                    b.Property<string>("SpeakerImage")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("SpeakerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SpeakerPhone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Api.Domain.Entities.SpeakerEventEntity", b =>
                {
                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpeakerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("EventEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("EventId", "SpeakerId");

                    b.HasIndex("EventEntityId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SpeakerEvents");
                });

            modelBuilder.Entity("Api.Domain.Entities.LotEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.EventEntity", "Event")
                        .WithMany("Lots")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Api.Domain.Entities.SocialMediaEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.EventEntity", "Event")
                        .WithMany("SocialMedias")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Domain.Entities.SpeakerEntity", "Speaker")
                        .WithMany("SocialMedias")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("Api.Domain.Entities.SpeakerEventEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.EventEntity", null)
                        .WithMany("Speakers")
                        .HasForeignKey("EventEntityId");

                    b.HasOne("Api.Domain.Entities.ListSocialMediaEntity", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.SpeakerEntity", "Speaker")
                        .WithMany("SpeakerEvents")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("Api.Domain.Entities.EventEntity", b =>
                {
                    b.Navigation("Lots");

                    b.Navigation("SocialMedias");

                    b.Navigation("Speakers");
                });

            modelBuilder.Entity("Api.Domain.Entities.SpeakerEntity", b =>
                {
                    b.Navigation("SocialMedias");

                    b.Navigation("SpeakerEvents");
                });
#pragma warning restore 612, 618
        }
    }
}