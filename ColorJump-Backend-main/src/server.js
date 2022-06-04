const userRouter = require('./routes/user.route');
var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var cors = require('cors');
const util = require( 'util' );
var server = require('http').createServer(app);
var port = 3000;
const db = require('./db/mongo-connection');

gameSocket = null;
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(cors());
app.use('/api', userRouter);
db();
server.listen(port, function(){
	console.log('listening on *:' + port + '--- server is running ...');
});

