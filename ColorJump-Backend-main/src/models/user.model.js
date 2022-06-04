var mongoose = require("mongoose");
const { multipleColumnSet } = require('../utils/common.utils');
const Role = require('../utils/userRoles.utils');

    
var UserSchema = new mongoose.Schema({
	username: {type: String},
	password: {type: String},
	email: {type: String}
});

module.exports = mongoose.model("User", UserSchema);
