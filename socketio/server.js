// JavaScript Document
/*
var http = require('http'),io = require('socket.io');
var server =http.createServer(function(req,res){
	res.writeHead(200,{'Content-Type': 'text/html'});
	res.end('<h1>Hello Socket Lover!</h1>');
	});
server.listen(8080);
var socket = io.listen(server);
socket.on('connection', function(client){   
        client.on('message',function(event){ 
                console.log('Received message from client!',event);
        });
        client.on('disconnect',function(){
                console.log('Server has disconnected');
        });
});*/
var app = require('express')();
var http = require('http').Server(app);
var httpPost = require('http');
var io = require('socket.io')(http);
var querystring = require('querystring');

var bodyParser = require('body-parser');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

//預設的client端
app.get('/', function(req, res){
  res.sendfile('client.html');
});
//接收參數 並且廣播給連線的使用者 //接著繼續傳遞給php處理
app.post('/holyshit',function(req,res){
	var message = req.body.jsondata;
	console.log(message);
	res.send(message);
	//廣播
	io.emit('message', 'command:'+message);
	//傳遞內容給php
	var data = querystring.stringify({
		jsondata: message
		});
	var options = {
			host: 'localhost',
			port: 80,
			path: '/index.aspx',
			method: 'POST',
			headers: {
				'Content-Type': 'application/x-www-form-urlencoded',
				'Content-Length': Buffer.byteLength(data)
			}
		};
	var req = httpPost.request(options, function(res) {
		res.setEncoding('utf8');
		res.on('data', function (chunk) {
			console.log("body: " + chunk);
		});
		
	});
	req.write(data);
	req.end();
});

//隨機選定名稱
	
io.on('connection', function(socket){
  socket.on('message', function(msg){
    io.emit('message', msg);
  });
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});