﻿

$('#likeParty').on("click", function () {
    alert("like Party!");
});

$('#dislikeParty').on("click", function () {
    let songId = playerParty.getPlaylist()[playerParty.getPlaylistIndex()];
    dislikeSong(playerParty, songId);
});

$('#likeChill').on("click", function () {
    alert("like Chill!");
});

$('#dislikeChill').on("click", function () {
    let songId = playerChill.getPlaylist()[playerChill.getPlaylistIndex()];
    dislikeSong(playerChill, songId);
});

$('#likeRage').on("click", function () {
    alert("like Rage!");
});

$('#dislikeRage').on("click", function () {
    let songId = playerRage.getPlaylist()[playerRage.getPlaylistIndex()];
    dislikeSong(playerRage, songId);
});

var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);


var playerParty;
var partyPlaylist = ['fSOpiZo1BAA', 'JkafqBj6dsk', 'cBVGlBWQzuc', 'mrZRURcb1cM'];

var playerChill;
var chillPlaylist = ['fSOpiZo1BAA', 'JkafqBj6dsk', 'cBVGlBWQzuc', 'mrZRURcb1cM'];

var playerRage;
var ragePlaylist = ['fSOpiZo1BAA', 'JkafqBj6dsk', 'cBVGlBWQzuc', 'mrZRURcb1cM'];

function onYouTubeIframeAPIReady() {
    playerParty = new YT.Player('partyvid', {
        height: '390',
        width: '640',
        events: {
            'onReady': onPartyPlayerReady,
        }
    });

    playerChill = new YT.Player('chillvid', {
        height: '390',
        width: '640',
        events: {
            'onReady': onChillPlayerReady,
        }
    });

    playerRage = new YT.Player('ragevid', {
        height: '390',
        width: '640',
        events: {
            'onReady': onRagePlayerReady,
        }
    });
}


function onPartyPlayerReady(event) {
    playerParty.cuePlaylist({
        listType: 'playlist',
        playlist: partyPlaylist,
        index: 0,
        startSeconds: 0,
        suggestedQuality: '360p'
    })
}

function onChillPlayerReady(event) {
    playerChill.cuePlaylist({
        listType: 'playlist',
        playlist: chillPlaylist,
        index: 0,
        startSeconds: 0,
        suggestedQuality: '360p'
    })
}

function onRagePlayerReady(event) {
    playerRage.cuePlaylist({
        listType: 'playlist',
        playlist: ragePlaylist,
        index: 0,
        startSeconds: 0,
        suggestedQuality: '360p'
    })
}

function dislikeSong(player, songId)
{
    let updatedPlaylist = removeSong(player, songId);
    if (player.getPlaylistIndex() > (updatedPlaylist.length - 1)) {
        reloadPlayer(player, updatedPlaylist, 0);
    }
    else
    {
        reloadPlayer(player, updatedPlaylist, player.getPlaylistIndex());
    }
}

function removeSong(player, songId) {
    //create an array without the disliked song
    let updatedPlaylist = player.getPlaylist().filter(currentSongId => currentSongId != songId);
    return updatedPlaylist;
}


function reloadPlayer(player, playlist, index)
{
    if (playlist.length != 0) {
        player.loadPlaylist({
            listType: 'playlist',
            playlist: playlist,
            index: index,
            startSeconds: 0,
            suggestedQuality: '360p',
        })
    }
    else
    {
        player.stopVideo();
        alert("I guess it is not your music type :)");
    }
}

