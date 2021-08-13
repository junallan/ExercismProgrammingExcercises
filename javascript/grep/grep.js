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

const run = () => {
	const fileNames = ARGS.filter(arguments => arguments.endsWith(".txt"));
	const wordMatch = /^[a-z]+$/i;
	const pattern = ARGS.filter(argument => wordMatch.test(argument.replace(/\s/g, "").replace(/[,.!'`]/g, "")));
	
	let flags = ARGS.filter(arguments => arguments.startsWith("-")); 

	for (fileName of fileNames) {
		const fileContents = readLines(fileName);

		let regex = new RegExp(pattern);

		if (flags.includes('-i')) regex = new RegExp(pattern, 'i');
		else if (flags.includes('-x')) regex = new RegExp('^' + pattern + '$');

		for (let i = 0; i < fileContents.length; i++) {
			const isOutput = !flags.includes('-v') && regex.test(fileContents[i]) ||
							 flags.includes('-v') && !regex.test(fileContents[i]);

			let result = fileNames.length > 1 ? `${fileName}:` : "";
		
			if (isOutput) {
				if (flags.includes('-l')) { console.log(fileName); break; }
				else if (flags.includes('-n')) result += `${i + 1}:${fileContents[i]}`;				
				else result += fileContents[i];

				console.log(result);
			}
		}
	}
}

run();
