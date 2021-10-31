// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

class Playlist {
	constructor(playlist) {
		this.collection = new Set(playlist);
	}

	getColletion() {
		return Array.from(this.collection);
	}

	getArtists() {
		let artists = new Set();

		for (const album of this.collection) {
			artists.add(album.split('-')[1].substring(1))
		}

		return Array.from(artists);
	}
}

/**
 * Removes duplicate tracks from a playlist.
 *
 * @param {string[]} playlist
 * @returns {string[]} new playlist with unique entries
 */
export function removeDuplicates(playlist) {
	return Array.from(new Playlist(playlist).collection);
}

/**
 * Checks whether a playlist includes a track.
 *
 * @param {string[]} playlist
 * @param {string} track
 * @returns {boolean} whether the track is in the playlist
 */
export function hasTrack(playlist, track) {
	return new Playlist(playlist).collection.has(track);
}

/**
 * Adds a track to a playlist.
 *
 * @param {string[]} playlist
 * @param {string} track
 * @returns {string[]} new playlist
 */
export function addTrack(playlist, track) {
	let playlistCollection = new Playlist(playlist);

	playlistCollection.collection.add(track)

	return playlistCollection.getColletion();
}

/**
 * Deletes a track from a playlist.
 *
 * @param {string[]} playlist
 * @param {string} track
 * @returns {string[]} new playlist
 */
export function deleteTrack(playlist, track) {
	let playlistCollection = new Playlist(playlist);

	playlistCollection.collection.delete(track)

	return playlistCollection.getColletion();
}

/**
 * Lists the unique artists in a playlist.
 *
 * @param {string[]} playlist
 * @returns {string[]} list of artists
 */
export function listArtists(playlist) {
	let playlistCollection = new Playlist(playlist);

	return playlistCollection.getArtists();
}
