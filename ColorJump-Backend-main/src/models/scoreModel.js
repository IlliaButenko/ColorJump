var mongoose = require("mongoose");
const { multipleColumnSet } = require('../utils/common.utils');
const Role = require('../utils/userRoles.utils');

    
var ScoreSchema = new mongoose.Schema({
	username: {type: String},
	email: {type: String},
	bestscore: {type: Number}
});

module.exports = mongoose.model("Score", ScoreSchema);
