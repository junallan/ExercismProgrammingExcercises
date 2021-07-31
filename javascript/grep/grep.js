#!/usr/bin/env node

// The above line is a shebang. On Unix-like operating systems, or environments,
// this will allow the script to be run by node, and thus turn this JavaScript
// file into an executable. In other words, to execute this file, you may run
// the following from your terminal:
//
// ./grep.js args
//
// If you don't have a Unix-like operating system or environment, for example
// Windows without WSL, you can use the following inside a window terminal,
// such as cmd.exe:
//
// node grep.js args
//
// Read more about shebangs here: https://en.wikipedia.org/wiki/Shebang_(Unix)

const fs = require('fs');
const path = require('path');

/**
 * Reads the given file and returns lines.
 *
 * This function works regardless of POSIX (LF) or windows (CRLF) encoding.
 *
 * @param {string} file path to file
 * @returns {string[]} the lines
 */
function readLines(file) {
	const data = fs.readFileSync(path.resolve(file), { encoding: 'utf-8' });
	//console.error(data.split(/\r?\n/));
	return data.split(/\r?\n/);
}

const VALID_OPTIONS = [
  'n', // add line numbers
  'l', // print file names where pattern is found
  'i', // ignore case
  'v', // reverse files results
  'x', // match entire line
];

const ARGS = process.argv;

//
// This is only a SKELETON file for the 'Grep' exercise. It's been provided as a
// convenience to get you started writing code faster.
//
// This file should *not* export a function. Use ARGS to determine what to grep
// and use console.log(output) to write to the standard output.
const run = () => {
	//console.log(ARGS);

	const fileName = ARGS[ARGS.length - 1];
	const flag = ARGS.length === 5 ? ARGS[2] : '';
	const pattern = ARGS.length == 5 ? ARGS[3] : ARGS[2];

	const fileContents = readLines(fileName);

	const regex = flag === '-i' ? new RegExp(pattern,'i') : new RegExp(pattern);

	for (let i = 0; i < fileContents.length; i++) {
		if (regex.test(fileContents[i])) {
			if (flag === '-n') console.log(`${i+1}:${fileContents[i]}`);
			else console.log(fileContents[i]);
		}
				
	}

	
}

run()
