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
                name: "Events",
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
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListSocialMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialMediaName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListSocialMedias", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserImage = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserEmail = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                        name: "FK_Lots_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    UrlSocialMedia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: true),
                    SpeakerId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
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
                        name: "FK_SpeakerEvents_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpeakerEvents_ListSocialMedias_EventId",
                        column: x => x.EventId,
                        principalTable: "ListSocialMedias",
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
                table: "ListSocialMedias",
                columns: new[] { "Id", "CreatedAt", "SocialMediaName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a6a00e7-a3a1-48a1-a859-50528cb1927c"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7900), "Vero", null },
                    { new Guid("10ab0383-ad73-438f-ae48-3511d18eff93"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8760), "Github", null },
                    { new Guid("1c1cc05e-ce3a-4352-8134-31e0b56007a3"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6380), "Twitter", null },
                    { new Guid("2353978e-c8b2-4b42-a189-34787ddecf44"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8250), "italki", null },
                    { new Guid("25f88e15-0624-464a-b540-e064e8ce7f93"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8680), "Odysee", null },
                    { new Guid("29042f90-2df2-4b32-bdbe-4097c647366b"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6560), "Skype", null },
                    { new Guid("2ede3eb6-3e78-47db-97a1-2a1fc94ea07e"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6990), "Pinterest", null },
                    { new Guid("3002e49a-70a0-418b-bda6-c994d998464c"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8590), "Parler", null },
                    { new Guid("3f54d9b4-22ef-46ab-9abb-7bb4a56c6482"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7720), "Upstream", null },
                    { new Guid("3fc33bad-f465-48aa-8919-0f8cc119d29a"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7460), "Badoo", null },
                    { new Guid("47945d9d-5fd0-4642-859f-c205330b09eb"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7640), "YouTube", null },
                    { new Guid("498833e8-8cb4-4fda-9124-7ee4726295e1"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6480), "Google+", null },
                    { new Guid("52f47efe-628b-4df0-8e28-c49d9cac9d78"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(5980), "Telegram", null },
                    { new Guid("53eefe41-f282-44f7-a6c1-87762537a1c1"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7980), "TikTok", null },
                    { new Guid("587a5277-78bb-40b7-9147-11093a5fdc27"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6110), "WeChat", null },
                    { new Guid("6b639348-b483-4e2d-bfcd-2715e4179ea2"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6910), "Snapchat", null },
                    { new Guid("74e705b9-ee1a-42e3-a1af-f60494343890"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8330), "Vimeo", null },
                    { new Guid("78aa886b-545e-42f2-8f72-ee825eb8a46c"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6650), "Viber", null },
                    { new Guid("7b8defbe-646d-4031-94b8-57961c07ccdf"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7270), "Taringa", null },
                    { new Guid("7e21aac0-f815-468e-901b-444ccd6781a3"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7090), "LinkedIn", null },
                    { new Guid("82f2daa9-ed11-45b6-8646-cc8bca3ab486"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7820), "MeetMe", null },
                    { new Guid("8a82d2c6-9ae7-417e-8b19-f36b5ed6778f"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7540), "Myspace", null },
                    { new Guid("a951494c-b327-4bab-b42e-6c0a9dca8270"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(3410), "Instagram", null },
                    { new Guid("ac0d56e4-f7ea-4608-a826-8a2c3a348344"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6200), "QZone", null },
                    { new Guid("af1b1374-4230-4600-a905-c1d8aa463a8b"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8070), "WT Social", null },
                    { new Guid("b04dddbd-922e-4443-94c5-babcfe4bde3e"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8420), "Gab", null },
                    { new Guid("be57d109-c83e-475f-998c-97586d324b21"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6830), "Sina Weibo", null },
                    { new Guid("c889da3c-22f0-4ee4-b3a0-3e00708f5064"), new DateTime(2021, 12, 30, 21, 18, 3, 928, DateTimeKind.Utc).AddTicks(1450), "Facebook", null },
                    { new Guid("cb71d345-582e-49de-8457-802ff7916c77"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(5810), "Gettr", null },
                    { new Guid("cc0a5955-08bc-4b93-9871-d6812c0db83a"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7170), "Reddit", null },
                    { new Guid("d49e60d3-0a1c-4e6e-b4a5-5042b010406c"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6290), "Tumblr", null },
                    { new Guid("dbdd672a-c688-4999-a281-6540ebce79de"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8160), "Caffeine", null },
                    { new Guid("e070cce7-ff24-4cdc-9b39-36dc8d64bf23"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(7360), "Foursquare", null },
                    { new Guid("ec872165-bf74-47e7-b6d7-78e11559d53e"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(6730), "line", null },
                    { new Guid("ff35d7d0-3b8a-46d6-9f73-deca0b04ce9e"), new DateTime(2021, 12, 30, 21, 18, 3, 968, DateTimeKind.Utc).AddTicks(8510), "Rumble", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Password", "Title", "UpdatedAt", "UserEmail", "UserImage", "UserName", "UserType" },
                values: new object[] { new Guid("4717560f-c9be-44b5-aa17-4d53effcb278"), new DateTime(2021, 12, 30, 21, 18, 3, 970, DateTimeKind.Utc).AddTicks(4070), true, "123456", "Tecnologo", null, "junior.garbage@gmail.com", "rosto.jpg", "Junior", "Admin" });

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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ListSocialMedias");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
