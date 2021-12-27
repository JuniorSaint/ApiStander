using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Local = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Theme = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PeopleAmount = table.Column<int>(type: "integer", nullable: false),
                    EventImage = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListSocialMediaEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialMediaName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListSocialMediaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpeakerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MiniResume = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    SpeakerImage = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    SpeakerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SpeakerEmail = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserIdentity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserImage = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LotName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    InitialDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_EventEntity_EventId",
                        column: x => x.EventId,
                        principalTable: "EventEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    URL = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true),
                    SpeakerId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_EventEntity_EventId",
                        column: x => x.EventId,
                        principalTable: "EventEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMedias_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerEvents",
                columns: table => new
                {
                    SpeakerId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerEvents", x => new { x.EventId, x.SpeakerId });
                    table.ForeignKey(
                        name: "FK_SpeakerEvents_EventEntity_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "EventEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpeakerEvents_ListSocialMediaEntity_EventId",
                        column: x => x.EventId,
                        principalTable: "ListSocialMediaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakerEvents_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ListSocialMediaEntity",
                columns: new[] { "Id", "CreatedAt", "SocialMediaName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("07cec255-3f6c-4d5a-8cad-4761ab3f7659"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3580), "Snapchat", null },
                    { new Guid("09188b13-b2a2-4758-83b7-db033cf24287"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4670), "Caffeine", null },
                    { new Guid("0a96c1f3-f59f-4ade-be30-1e173420801c"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4510), "TikTok", null },
                    { new Guid("0bb53dfc-edd9-4334-b91d-5f83d7c01790"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(530), "Instagram", null },
                    { new Guid("0f2e4538-c295-485c-9b6e-0e197ba0f8f2"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4210), "YouTube", null },
                    { new Guid("12267324-0996-49fb-986a-78acf7527221"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4060), "Badoo", null },
                    { new Guid("1530bfdf-9c22-416b-9787-ea9f09366af2"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3180), "Google+", null },
                    { new Guid("15d3309c-1536-4e1e-acc0-29298a03c799"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3890), "Taringa", null },
                    { new Guid("1c975d64-b90d-4be5-8fe1-0d03b5666b10"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4750), "italki", null },
                    { new Guid("1dca59a8-5b12-41fe-8fb7-173c813c1e5e"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3740), "LinkedIn", null },
                    { new Guid("21da8b6c-d49c-448a-aed1-49f29a58411f"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3260), "Skype", null },
                    { new Guid("23ed49af-c2cc-436a-a3d7-4e2835ac9dec"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3970), "Foursquare", null },
                    { new Guid("29a36971-5b6d-4e9b-9abb-f446b496d4fe"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(5130), "Odysee", null },
                    { new Guid("33edbe6b-ab83-4268-b2a8-a40e0d233259"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(5050), "Parler", null },
                    { new Guid("3720e5ed-e5bf-42b6-8a7e-b089fdef01f9"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3500), "Sina Weibo", null },
                    { new Guid("3ddb80fe-c9a8-49c6-9fb6-d0011c15ceca"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4290), "Upstream", null },
                    { new Guid("4182ed6c-0fda-4ed4-a5e2-4355d12f4182"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3650), "Pinterest", null },
                    { new Guid("519cfcf1-5efa-4f64-a778-c6bc09b8ea1d"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3080), "Twitter", null },
                    { new Guid("5800ce15-ebe5-4903-9010-db00d9c6486a"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4130), "Myspace", null },
                    { new Guid("5a43a259-84b7-4a8f-9706-9ddb3b38f2ad"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3420), "line", null },
                    { new Guid("5f81856f-e4b9-4160-b665-6985a0e2fa13"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4820), "Vimeo", null },
                    { new Guid("750e0ada-6a8d-40fd-8f1c-f8c568a5f908"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(2480), "Gettr", null },
                    { new Guid("835427f0-e8f3-4eba-8fb4-be0f1f62ad66"), new DateTime(2021, 12, 15, 14, 2, 6, 213, DateTimeKind.Utc).AddTicks(1350), "Facebook", null },
                    { new Guid("83cd3309-9727-4238-8d68-1bfa39f5705b"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4980), "Rumble", null },
                    { new Guid("84e932d0-09ea-4adf-8756-623953d5750c"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3000), "Tumblr", null },
                    { new Guid("9e97a4f5-7a9d-42df-a2c3-33186255e758"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(2910), "QZone", null },
                    { new Guid("a0933bc7-8443-416e-aac0-763191dd1011"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(5200), "Github", null },
                    { new Guid("b1fd397a-7ff6-40b5-a4e4-9a808c1e523f"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3810), "Reddit", null },
                    { new Guid("c89a7270-ffa5-4822-9b95-f88b788e1fc5"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4440), "Vero", null },
                    { new Guid("d7daebf4-7d12-4bdd-968f-4d15e40606d3"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4600), "WT Social", null },
                    { new Guid("d872986f-0b4b-4f2d-90b9-29efdc02d1c4"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(2820), "WeChat", null },
                    { new Guid("e38c3125-5535-4f44-8038-18f91635444a"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4890), "Gab", null },
                    { new Guid("f300af93-b4c6-40de-8a58-9334c0c68a25"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(2650), "Telegram", null },
                    { new Guid("f54bfbc0-af0a-44ec-8c80-83f7f2976a90"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(4360), "MeetMe", null },
                    { new Guid("f5935f0e-cdb7-4d91-a912-e057e9d64987"), new DateTime(2021, 12, 15, 14, 2, 6, 251, DateTimeKind.Utc).AddTicks(3340), "Viber", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_EventId",
                table: "Lots",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_EventId",
                table: "SocialMedias",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_SpeakerId",
                table: "SocialMedias",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEvents_EventEntityId",
                table: "SpeakerEvents",
                column: "EventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerEvents_SpeakerId",
                table: "SpeakerEvents",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "SpeakerEvents");

            migrationBuilder.DropTable(
                name: "UserIdentity");

            migrationBuilder.DropTable(
                name: "EventEntity");

            migrationBuilder.DropTable(
                name: "ListSocialMediaEntity");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
