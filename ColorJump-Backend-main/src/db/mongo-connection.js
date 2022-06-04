const mongoose = require('mongoose');
const vars = require('./var.config.js');

// Exit app on error
mongoose.connection.on('error', (err) => {
    console.error(`MongoDB connection error: ${err}`);
    process.exit(-1);
})


const db = () => {
    console.log(vars.mongo.uri);
    mongoose.connect(vars.mongo.uri, {
        useCreateIndex: true,
        keepAlive: 1,
        useNewUrlParser: true,
        useUnifiedTopology: true,
        useFindAndModify: false,
    })
        .then(() => {
            console.info('MongoDB connection success');
        })
    

    return mongoose.connection;
}
module.exports = db;
