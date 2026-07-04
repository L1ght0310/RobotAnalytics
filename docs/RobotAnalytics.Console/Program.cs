var client = new UrScriptClient();

await client.ConnectAsync();

await client.SendAsync(@"
movej([0, -2, 1, -1.57, 0, 0], a=1.2, v=1.0)
");