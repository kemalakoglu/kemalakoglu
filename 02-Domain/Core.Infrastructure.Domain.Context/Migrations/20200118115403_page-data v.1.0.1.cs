﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Domain.Context.Migrations
{
    public partial class pagedatav101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
USE [kemalakoglu]
GO
SET IDENTITY_INSERT [dbo].[RefType] ON 

INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (1, 1, CAST(N'2019-07-09T12:34:57.7610000' AS DateTime2), NULL, 1, N'Page', NULL)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (8, 0, CAST(N'2019-12-12T09:06:36.5595823' AS DateTime2), CAST(N'2019-12-24T09:25:50.2691270' AS DateTime2), 0, N'Home', 1)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (27, 1, CAST(N'2019-12-24T13:14:20.8895397' AS DateTime2), CAST(N'2019-12-24T15:36:59.1251286' AS DateTime2), 1, N'Home', 1)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (28, 1, CAST(N'2019-12-24T16:33:59.9330757' AS DateTime2), CAST(N'2020-01-06T13:05:14.6561201' AS DateTime2), 1, N'ASP.NET Core', 1)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (29, 1, CAST(N'2020-01-06T13:05:27.0706304' AS DateTime2), NULL, 1, N'Angular', 1)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (30, 1, CAST(N'2020-01-06T13:05:44.5438291' AS DateTime2), NULL, 1, N'React JS', 1)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (31, 1, CAST(N'2020-01-06T13:06:37.6281473' AS DateTime2), CAST(N'2020-01-06T13:08:59.0103851' AS DateTime2), 1, N'Design Pattern', 1)
INSERT [dbo].[RefType] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Name], [ParentId]) VALUES (32, 1, CAST(N'2020-01-06T13:08:11.3338645' AS DateTime2), NULL, 1, N'Approach', 1)
SET IDENTITY_INSERT [dbo].[RefType] OFF
SET IDENTITY_INSERT [dbo].[RefValue] ON 

INSERT [dbo].[RefValue] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Value], [RefTypeId], [Name]) VALUES (24, 1, CAST(N'2019-12-25T10:51:39.5536808' AS DateTime2), CAST(N'2020-01-07T10:15:03.5860825' AS DateTime2), 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse facilisis mollis erat ut ultrices. Nunc dignissim dui nisi, et lobortis nisi auctor at. Quisque semper, leo ut consectetur commodo, nunc nibh ullamcorper libero, eu dictum turpis orci ut nulla. Integer vitae condimentum nisl. Fusce vel dolor sed dolor maximus porttitor eget at nibh. Fusce faucibus dui diam, sed fermentum tortor tempor a. Curabitur pellentesque turpis velit, eu mattis neque imperdiet a. Vestibulum dapibus odio posuere, lacinia quam id, rhoncus tellus.Sed eu viverra quam, vitae pretium sapien. Vestibulum sed tortor eget eros fermentum molestie ut sit amet lacus. Vivamus finibus urna vitae velit tempus, in porttitor lectus rhoncus. Etiam in leo neque. Aliquam ut nisi posuere, lacinia lectus at, scelerisque tortor. Donec in varius erat, et placerat massa. Integer porta facilisis felis, sit amet pharetra purus euismod eget.Fusce accumsan sem tellus, at sagittis est condimentum id. Maecenas dignissim aliquam neque et maximus. In mollis ullamcorper nibh, ut dapibus nisi tincidunt nec. Phasellus vel ex nulla. Vivamus interdum, lectus at commodo ultricies, purus tellus semper velit, sit amet imperdiet ligula sapien sit amet massa. Nulla tempor vehicula nulla, eget ultricies libero posuere ac. Fusce porta mollis imperdiet. Ut ac ex lacinia, condimentum mauris id, tincidunt quam. Duis ex elit, feugiat et neque non, accumsan vestibulum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis eu interdum orci, vel vestibulum nulla. Mauris nec arcu vel dolor ullamcorper pellentesque. Pellentesque sed lectus diam. Aenean vestibulum est nec metus facilisis, non mattis tellus dignissim.In hac habitasse platea dictumst. In tristique hendrerit augue nec consequat. Phasellus id feugiat risus. Nulla eleifend porttitor arcu, vitae maximus justo dignissim vitae. Sed iaculis orci at ipsum gravida tempus. Vestibulum interdum quam at eros porta, id ullamcorper lorem egestas. Ut eget lectus vitae ex viverra rutrum. Maecenas imperdiet quam lorem, eu condimentum metus finibus vel. Nunc sed erat id neque aliquet hendrerit eu vel tellus. Duis aliquet bibendum sapien quis imperdiet. Nam eu elit eu leo sodales vehicula vel ac augue. Integer neque quam, placerat eu consequat pellentesque, facilisis elementum quam. Sed dapibus felis id nisi efficitur, sed bibendum nulla porta. Donec lectus tortor, tempus id cursus in, rutrum vel augue.Praesent tristique hendrerit leo, a viverra nunc. Duis rhoncus nec nunc id mollis. Sed et ex eu risus tempor mattis vel nec quam. Fusce maximus ante libero, eu varius eros dapibus consectetur. Sed et elit metus. Aenean ut mi mattis, viverra urna eu, vehicula tortor. In placerat tortor vitae neque accumsan imperdiet a nec mi. Ut ut euismod erat. Ut ut purus viverra, scelerisque erat vel, vulputate arcu. Cras consequat turpis pharetra orci blandit, vitae volutpat sapien auctor. Sed in augue mollis, tincidunt sapien in, aliquet tellus. Aenean semper elit quis dui dapibus egestas. Phasellus quis lectus nisi. Integer dignissim laoreet lectus ac pretium. Morbi congue sollicitudin finibus. Sed sed augue ut massa suscipit pellentesque varius sit amet ligula.', 29, N'angular')
INSERT [dbo].[RefValue] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Value], [RefTypeId], [Name]) VALUES (25, 1, CAST(N'2020-01-07T10:14:13.0009417' AS DateTime2), CAST(N'2020-01-07T10:14:48.4543639' AS DateTime2), 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse facilisis mollis erat ut ultrices. Nunc dignissim dui nisi, et lobortis nisi auctor at. Quisque semper, leo ut consectetur commodo, nunc nibh ullamcorper libero, eu dictum turpis orci ut nulla. Integer vitae condimentum nisl. Fusce vel dolor sed dolor maximus porttitor eget at nibh. Fusce faucibus dui diam, sed fermentum tortor tempor a. Curabitur pellentesque turpis velit, eu mattis neque imperdiet a. Vestibulum dapibus odio posuere, lacinia quam id, rhoncus tellus.Sed eu viverra quam, vitae pretium sapien. Vestibulum sed tortor eget eros fermentum molestie ut sit amet lacus. Vivamus finibus urna vitae velit tempus, in porttitor lectus rhoncus. Etiam in leo neque. Aliquam ut nisi posuere, lacinia lectus at, scelerisque tortor. Donec in varius erat, et placerat massa. Integer porta facilisis felis, sit amet pharetra purus euismod eget.Fusce accumsan sem tellus, at sagittis est condimentum id. Maecenas dignissim aliquam neque et maximus. In mollis ullamcorper nibh, ut dapibus nisi tincidunt nec. Phasellus vel ex nulla. Vivamus interdum, lectus at commodo ultricies, purus tellus semper velit, sit amet imperdiet ligula sapien sit amet massa. Nulla tempor vehicula nulla, eget ultricies libero posuere ac. Fusce porta mollis imperdiet. Ut ac ex lacinia, condimentum mauris id, tincidunt quam. Duis ex elit, feugiat et neque non, accumsan vestibulum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis eu interdum orci, vel vestibulum nulla. Mauris nec arcu vel dolor ullamcorper pellentesque. Pellentesque sed lectus diam. Aenean vestibulum est nec metus facilisis, non mattis tellus dignissim.In hac habitasse platea dictumst. In tristique hendrerit augue nec consequat. Phasellus id feugiat risus. Nulla eleifend porttitor arcu, vitae maximus justo dignissim vitae. Sed iaculis orci at ipsum gravida tempus. Vestibulum interdum quam at eros porta, id ullamcorper lorem egestas. Ut eget lectus vitae ex viverra rutrum. Maecenas imperdiet quam lorem, eu condimentum metus finibus vel. Nunc sed erat id neque aliquet hendrerit eu vel tellus. Duis aliquet bibendum sapien quis imperdiet. Nam eu elit eu leo sodales vehicula vel ac augue. Integer neque quam, placerat eu consequat pellentesque, facilisis elementum quam. Sed dapibus felis id nisi efficitur, sed bibendum nulla porta. Donec lectus tortor, tempus id cursus in, rutrum vel augue.Praesent tristique hendrerit leo, a viverra nunc. Duis rhoncus nec nunc id mollis. Sed et ex eu risus tempor mattis vel nec quam. Fusce maximus ante libero, eu varius eros dapibus consectetur. Sed et elit metus. Aenean ut mi mattis, viverra urna eu, vehicula tortor. In placerat tortor vitae neque accumsan imperdiet a nec mi. Ut ut euismod erat. Ut ut purus viverra, scelerisque erat vel, vulputate arcu. Cras consequat turpis pharetra orci blandit, vitae volutpat sapien auctor. Sed in augue mollis, tincidunt sapien in, aliquet tellus. Aenean semper elit quis dui dapibus egestas. Phasellus quis lectus nisi. Integer dignissim laoreet lectus ac pretium. Morbi congue sollicitudin finibus. Sed sed augue ut massa suscipit pellentesque varius sit amet ligula.', 28, N'.Net Core')
INSERT [dbo].[RefValue] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Value], [RefTypeId], [Name]) VALUES (26, 1, CAST(N'2020-01-07T10:15:21.8213337' AS DateTime2), CAST(N'2020-01-07T10:15:30.7721062' AS DateTime2), 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse facilisis mollis erat ut ultrices. Nunc dignissim dui nisi, et lobortis nisi auctor at. Quisque semper, leo ut consectetur commodo, nunc nibh ullamcorper libero, eu dictum turpis orci ut nulla. Integer vitae condimentum nisl. Fusce vel dolor sed dolor maximus porttitor eget at nibh. Fusce faucibus dui diam, sed fermentum tortor tempor a. Curabitur pellentesque turpis velit, eu mattis neque imperdiet a. Vestibulum dapibus odio posuere, lacinia quam id, rhoncus tellus.Sed eu viverra quam, vitae pretium sapien. Vestibulum sed tortor eget eros fermentum molestie ut sit amet lacus. Vivamus finibus urna vitae velit tempus, in porttitor lectus rhoncus. Etiam in leo neque. Aliquam ut nisi posuere, lacinia lectus at, scelerisque tortor. Donec in varius erat, et placerat massa. Integer porta facilisis felis, sit amet pharetra purus euismod eget.Fusce accumsan sem tellus, at sagittis est condimentum id. Maecenas dignissim aliquam neque et maximus. In mollis ullamcorper nibh, ut dapibus nisi tincidunt nec. Phasellus vel ex nulla. Vivamus interdum, lectus at commodo ultricies, purus tellus semper velit, sit amet imperdiet ligula sapien sit amet massa. Nulla tempor vehicula nulla, eget ultricies libero posuere ac. Fusce porta mollis imperdiet. Ut ac ex lacinia, condimentum mauris id, tincidunt quam. Duis ex elit, feugiat et neque non, accumsan vestibulum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis eu interdum orci, vel vestibulum nulla. Mauris nec arcu vel dolor ullamcorper pellentesque. Pellentesque sed lectus diam. Aenean vestibulum est nec metus facilisis, non mattis tellus dignissim.In hac habitasse platea dictumst. In tristique hendrerit augue nec consequat. Phasellus id feugiat risus. Nulla eleifend porttitor arcu, vitae maximus justo dignissim vitae. Sed iaculis orci at ipsum gravida tempus. Vestibulum interdum quam at eros porta, id ullamcorper lorem egestas. Ut eget lectus vitae ex viverra rutrum. Maecenas imperdiet quam lorem, eu condimentum metus finibus vel. Nunc sed erat id neque aliquet hendrerit eu vel tellus. Duis aliquet bibendum sapien quis imperdiet. Nam eu elit eu leo sodales vehicula vel ac augue. Integer neque quam, placerat eu consequat pellentesque, facilisis elementum quam. Sed dapibus felis id nisi efficitur, sed bibendum nulla porta. Donec lectus tortor, tempus id cursus in, rutrum vel augue.Praesent tristique hendrerit leo, a viverra nunc. Duis rhoncus nec nunc id mollis. Sed et ex eu risus tempor mattis vel nec quam. Fusce maximus ante libero, eu varius eros dapibus consectetur. Sed et elit metus. Aenean ut mi mattis, viverra urna eu, vehicula tortor. In placerat tortor vitae neque accumsan imperdiet a nec mi. Ut ut euismod erat. Ut ut purus viverra, scelerisque erat vel, vulputate arcu. Cras consequat turpis pharetra orci blandit, vitae volutpat sapien auctor. Sed in augue mollis, tincidunt sapien in, aliquet tellus. Aenean semper elit quis dui dapibus egestas. Phasellus quis lectus nisi. Integer dignissim laoreet lectus ac pretium. Morbi congue sollicitudin finibus. Sed sed augue ut massa suscipit pellentesque varius sit amet ligula.', 30, N'React')
INSERT [dbo].[RefValue] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Value], [RefTypeId], [Name]) VALUES (27, 1, CAST(N'2020-01-07T10:15:47.7939582' AS DateTime2), CAST(N'2020-01-07T10:16:37.5209053' AS DateTime2), 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse facilisis mollis erat ut ultrices. Nunc dignissim dui nisi, et lobortis nisi auctor at. Quisque semper, leo ut consectetur commodo, nunc nibh ullamcorper libero, eu dictum turpis orci ut nulla. Integer vitae condimentum nisl. Fusce vel dolor sed dolor maximus porttitor eget at nibh. Fusce faucibus dui diam, sed fermentum tortor tempor a. Curabitur pellentesque turpis velit, eu mattis neque imperdiet a. Vestibulum dapibus odio posuere, lacinia quam id, rhoncus tellus.Sed eu viverra quam, vitae pretium sapien. Vestibulum sed tortor eget eros fermentum molestie ut sit amet lacus. Vivamus finibus urna vitae velit tempus, in porttitor lectus rhoncus. Etiam in leo neque. Aliquam ut nisi posuere, lacinia lectus at, scelerisque tortor. Donec in varius erat, et placerat massa. Integer porta facilisis felis, sit amet pharetra purus euismod eget.Fusce accumsan sem tellus, at sagittis est condimentum id. Maecenas dignissim aliquam neque et maximus. In mollis ullamcorper nibh, ut dapibus nisi tincidunt nec. Phasellus vel ex nulla. Vivamus interdum, lectus at commodo ultricies, purus tellus semper velit, sit amet imperdiet ligula sapien sit amet massa. Nulla tempor vehicula nulla, eget ultricies libero posuere ac. Fusce porta mollis imperdiet. Ut ac ex lacinia, condimentum mauris id, tincidunt quam. Duis ex elit, feugiat et neque non, accumsan vestibulum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis eu interdum orci, vel vestibulum nulla. Mauris nec arcu vel dolor ullamcorper pellentesque. Pellentesque sed lectus diam. Aenean vestibulum est nec metus facilisis, non mattis tellus dignissim.In hac habitasse platea dictumst. In tristique hendrerit augue nec consequat. Phasellus id feugiat risus. Nulla eleifend porttitor arcu, vitae maximus justo dignissim vitae. Sed iaculis orci at ipsum gravida tempus. Vestibulum interdum quam at eros porta, id ullamcorper lorem egestas. Ut eget lectus vitae ex viverra rutrum. Maecenas imperdiet quam lorem, eu condimentum metus finibus vel. Nunc sed erat id neque aliquet hendrerit eu vel tellus. Duis aliquet bibendum sapien quis imperdiet. Nam eu elit eu leo sodales vehicula vel ac augue. Integer neque quam, placerat eu consequat pellentesque, facilisis elementum quam. Sed dapibus felis id nisi efficitur, sed bibendum nulla porta. Donec lectus tortor, tempus id cursus in, rutrum vel augue.Praesent tristique hendrerit leo, a viverra nunc. Duis rhoncus nec nunc id mollis. Sed et ex eu risus tempor mattis vel nec quam. Fusce maximus ante libero, eu varius eros dapibus consectetur. Sed et elit metus. Aenean ut mi mattis, viverra urna eu, vehicula tortor. In placerat tortor vitae neque accumsan imperdiet a nec mi. Ut ut euismod erat. Ut ut purus viverra, scelerisque erat vel, vulputate arcu. Cras consequat turpis pharetra orci blandit, vitae volutpat sapien auctor. Sed in augue mollis, tincidunt sapien in, aliquet tellus. Aenean semper elit quis dui dapibus egestas. Phasellus quis lectus nisi. Integer dignissim laoreet lectus ac pretium. Morbi congue sollicitudin finibus. Sed sed augue ut massa suscipit pellentesque varius sit amet ligula.', 32, N'approach')
INSERT [dbo].[RefValue] ([Id], [Status], [InsertDate], [UpdateDate], [IsActive], [Value], [RefTypeId], [Name]) VALUES (28, 1, CAST(N'2020-01-07T10:16:25.9063304' AS DateTime2), CAST(N'2020-01-07T10:16:43.9093067' AS DateTime2), 1, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse facilisis mollis erat ut ultrices. Nunc dignissim dui nisi, et lobortis nisi auctor at. Quisque semper, leo ut consectetur commodo, nunc nibh ullamcorper libero, eu dictum turpis orci ut nulla. Integer vitae condimentum nisl. Fusce vel dolor sed dolor maximus porttitor eget at nibh. Fusce faucibus dui diam, sed fermentum tortor tempor a. Curabitur pellentesque turpis velit, eu mattis neque imperdiet a. Vestibulum dapibus odio posuere, lacinia quam id, rhoncus tellus.Sed eu viverra quam, vitae pretium sapien. Vestibulum sed tortor eget eros fermentum molestie ut sit amet lacus. Vivamus finibus urna vitae velit tempus, in porttitor lectus rhoncus. Etiam in leo neque. Aliquam ut nisi posuere, lacinia lectus at, scelerisque tortor. Donec in varius erat, et placerat massa. Integer porta facilisis felis, sit amet pharetra purus euismod eget.Fusce accumsan sem tellus, at sagittis est condimentum id. Maecenas dignissim aliquam neque et maximus. In mollis ullamcorper nibh, ut dapibus nisi tincidunt nec. Phasellus vel ex nulla. Vivamus interdum, lectus at commodo ultricies, purus tellus semper velit, sit amet imperdiet ligula sapien sit amet massa. Nulla tempor vehicula nulla, eget ultricies libero posuere ac. Fusce porta mollis imperdiet. Ut ac ex lacinia, condimentum mauris id, tincidunt quam. Duis ex elit, feugiat et neque non, accumsan vestibulum tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis eu interdum orci, vel vestibulum nulla. Mauris nec arcu vel dolor ullamcorper pellentesque. Pellentesque sed lectus diam. Aenean vestibulum est nec metus facilisis, non mattis tellus dignissim.In hac habitasse platea dictumst. In tristique hendrerit augue nec consequat. Phasellus id feugiat risus. Nulla eleifend porttitor arcu, vitae maximus justo dignissim vitae. Sed iaculis orci at ipsum gravida tempus. Vestibulum interdum quam at eros porta, id ullamcorper lorem egestas. Ut eget lectus vitae ex viverra rutrum. Maecenas imperdiet quam lorem, eu condimentum metus finibus vel. Nunc sed erat id neque aliquet hendrerit eu vel tellus. Duis aliquet bibendum sapien quis imperdiet. Nam eu elit eu leo sodales vehicula vel ac augue. Integer neque quam, placerat eu consequat pellentesque, facilisis elementum quam. Sed dapibus felis id nisi efficitur, sed bibendum nulla porta. Donec lectus tortor, tempus id cursus in, rutrum vel augue.Praesent tristique hendrerit leo, a viverra nunc. Duis rhoncus nec nunc id mollis. Sed et ex eu risus tempor mattis vel nec quam. Fusce maximus ante libero, eu varius eros dapibus consectetur. Sed et elit metus. Aenean ut mi mattis, viverra urna eu, vehicula tortor. In placerat tortor vitae neque accumsan imperdiet a nec mi. Ut ut euismod erat. Ut ut purus viverra, scelerisque erat vel, vulputate arcu. Cras consequat turpis pharetra orci blandit, vitae volutpat sapien auctor. Sed in augue mollis, tincidunt sapien in, aliquet tellus. Aenean semper elit quis dui dapibus egestas. Phasellus quis lectus nisi. Integer dignissim laoreet lectus ac pretium. Morbi congue sollicitudin finibus. Sed sed augue ut massa suscipit pellentesque varius sit amet ligula.', 31, N'design pattern')
SET IDENTITY_INSERT [dbo].[RefValue] OFF
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}