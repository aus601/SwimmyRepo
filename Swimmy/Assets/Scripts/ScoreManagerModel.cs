using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class ScoreManagerModel
{
    [RealtimeProperty(1, true, true)]
    private int _player1Score = 0;

    [RealtimeProperty(2, true, true)]
    private int _player2Score = 0;

    [RealtimeProperty(3, true, true)]
    private int _player3Score = 0;

    [RealtimeProperty(4, true, true)]
    private int _player4Score = 0;

    [RealtimeProperty(5, true, true)]
    private int _player5Score = 0;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class ScoreManagerModel : IModel {
    // Properties
    public int player1Score {
        get { return _cache.LookForValueInCache(_player1Score, entry => entry.player1ScoreSet, entry => entry.player1Score); }
        set { if (value == player1Score) return; _cache.UpdateLocalCache(entry => { entry.player1ScoreSet = true; entry.player1Score = value; return entry; }); FirePlayer1ScoreDidChange(value); }
    }
    public int player2Score {
        get { return _cache.LookForValueInCache(_player2Score, entry => entry.player2ScoreSet, entry => entry.player2Score); }
        set { if (value == player2Score) return; _cache.UpdateLocalCache(entry => { entry.player2ScoreSet = true; entry.player2Score = value; return entry; }); FirePlayer2ScoreDidChange(value); }
    }
    public int player3Score {
        get { return _cache.LookForValueInCache(_player3Score, entry => entry.player3ScoreSet, entry => entry.player3Score); }
        set { if (value == player3Score) return; _cache.UpdateLocalCache(entry => { entry.player3ScoreSet = true; entry.player3Score = value; return entry; }); FirePlayer3ScoreDidChange(value); }
    }
    public int player4Score {
        get { return _cache.LookForValueInCache(_player4Score, entry => entry.player4ScoreSet, entry => entry.player4Score); }
        set { if (value == player4Score) return; _cache.UpdateLocalCache(entry => { entry.player4ScoreSet = true; entry.player4Score = value; return entry; }); FirePlayer4ScoreDidChange(value); }
    }
    public int player5Score {
        get { return _cache.LookForValueInCache(_player5Score, entry => entry.player5ScoreSet, entry => entry.player5Score); }
        set { if (value == player5Score) return; _cache.UpdateLocalCache(entry => { entry.player5ScoreSet = true; entry.player5Score = value; return entry; }); FirePlayer5ScoreDidChange(value); }
    }
    
    // Events
    public delegate void Player1ScoreDidChange(ScoreManagerModel model, int value);
    public event         Player1ScoreDidChange player1ScoreDidChange;
    public delegate void Player2ScoreDidChange(ScoreManagerModel model, int value);
    public event         Player2ScoreDidChange player2ScoreDidChange;
    public delegate void Player3ScoreDidChange(ScoreManagerModel model, int value);
    public event         Player3ScoreDidChange player3ScoreDidChange;
    public delegate void Player4ScoreDidChange(ScoreManagerModel model, int value);
    public event         Player4ScoreDidChange player4ScoreDidChange;
    public delegate void Player5ScoreDidChange(ScoreManagerModel model, int value);
    public event         Player5ScoreDidChange player5ScoreDidChange;
    
    // Delta updates
    private struct LocalCacheEntry {
        public bool player1ScoreSet;
        public int  player1Score;
        public bool player2ScoreSet;
        public int  player2Score;
        public bool player3ScoreSet;
        public int  player3Score;
        public bool player4ScoreSet;
        public int  player4Score;
        public bool player5ScoreSet;
        public int  player5Score;
    }
    
    private LocalChangeCache<LocalCacheEntry> _cache;
    
    public ScoreManagerModel() {
        _cache = new LocalChangeCache<LocalCacheEntry>();
    }
    
    // Events
    public void FirePlayer1ScoreDidChange(int value) {
        try {
            if (player1ScoreDidChange != null)
                player1ScoreDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FirePlayer2ScoreDidChange(int value) {
        try {
            if (player2ScoreDidChange != null)
                player2ScoreDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FirePlayer3ScoreDidChange(int value) {
        try {
            if (player3ScoreDidChange != null)
                player3ScoreDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FirePlayer4ScoreDidChange(int value) {
        try {
            if (player4ScoreDidChange != null)
                player4ScoreDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FirePlayer5ScoreDidChange(int value) {
        try {
            if (player5ScoreDidChange != null)
                player5ScoreDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    
    // Serialization
    enum PropertyID {
        Player1Score = 1,
        Player2Score = 2,
        Player3Score = 3,
        Player4Score = 4,
        Player5Score = 5,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Mark unreliable properties as clean and flatten the in-flight cache.
            // TODO: Move this out of WriteLength() once we have a prepareToWrite method.
            _player1Score = player1Score;
            _player2Score = player2Score;
            _player3Score = player3Score;
            _player4Score = player4Score;
            _player5Score = player5Score;
            _cache.Clear();
            
            // Write all properties
            length += WriteStream.WriteVarint32Length((uint)PropertyID.Player1Score, (uint)_player1Score);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.Player2Score, (uint)_player2Score);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.Player3Score, (uint)_player3Score);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.Player4Score, (uint)_player4Score);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.Player5Score, (uint)_player5Score);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.player1ScoreSet)
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.Player1Score, (uint)entry.player1Score);
                if (entry.player2ScoreSet)
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.Player2Score, (uint)entry.player2Score);
                if (entry.player3ScoreSet)
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.Player3Score, (uint)entry.player3Score);
                if (entry.player4ScoreSet)
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.Player4Score, (uint)entry.player4Score);
                if (entry.player5ScoreSet)
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.Player5Score, (uint)entry.player5Score);
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteVarint32((uint)PropertyID.Player1Score, (uint)_player1Score);
            stream.WriteVarint32((uint)PropertyID.Player2Score, (uint)_player2Score);
            stream.WriteVarint32((uint)PropertyID.Player3Score, (uint)_player3Score);
            stream.WriteVarint32((uint)PropertyID.Player4Score, (uint)_player4Score);
            stream.WriteVarint32((uint)PropertyID.Player5Score, (uint)_player5Score);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.player1ScoreSet || entry.player2ScoreSet || entry.player3ScoreSet || entry.player4ScoreSet || entry.player5ScoreSet)
                    _cache.PushLocalCacheToInflight(context.updateID);
                
                if (entry.player1ScoreSet)
                    stream.WriteVarint32((uint)PropertyID.Player1Score, (uint)entry.player1Score);
                if (entry.player2ScoreSet)
                    stream.WriteVarint32((uint)PropertyID.Player2Score, (uint)entry.player2Score);
                if (entry.player3ScoreSet)
                    stream.WriteVarint32((uint)PropertyID.Player3Score, (uint)entry.player3Score);
                if (entry.player4ScoreSet)
                    stream.WriteVarint32((uint)PropertyID.Player4Score, (uint)entry.player4Score);
                if (entry.player5ScoreSet)
                    stream.WriteVarint32((uint)PropertyID.Player5Score, (uint)entry.player5Score);
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        bool player1ScoreExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.player1ScoreSet);
        bool player2ScoreExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.player2ScoreSet);
        bool player3ScoreExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.player3ScoreSet);
        bool player4ScoreExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.player4ScoreSet);
        bool player5ScoreExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.player5ScoreSet);
        
        // Remove from in-flight
        if (context.deltaUpdatesOnly && context.reliableChannel)
            _cache.RemoveUpdateFromInflight(context.updateID);
        
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.Player1Score: {
                    int previousValue = _player1Score;
                    
                    _player1Score = (int)stream.ReadVarint32();
                    
                    if (!player1ScoreExistsInChangeCache && _player1Score != previousValue)
                        FirePlayer1ScoreDidChange(_player1Score);
                    break;
                }
                case (uint)PropertyID.Player2Score: {
                    int previousValue = _player2Score;
                    
                    _player2Score = (int)stream.ReadVarint32();
                    
                    if (!player2ScoreExistsInChangeCache && _player2Score != previousValue)
                        FirePlayer2ScoreDidChange(_player2Score);
                    break;
                }
                case (uint)PropertyID.Player3Score: {
                    int previousValue = _player3Score;
                    
                    _player3Score = (int)stream.ReadVarint32();
                    
                    if (!player3ScoreExistsInChangeCache && _player3Score != previousValue)
                        FirePlayer3ScoreDidChange(_player3Score);
                    break;
                }
                case (uint)PropertyID.Player4Score: {
                    int previousValue = _player4Score;
                    
                    _player4Score = (int)stream.ReadVarint32();
                    
                    if (!player4ScoreExistsInChangeCache && _player4Score != previousValue)
                        FirePlayer4ScoreDidChange(_player4Score);
                    break;
                }
                case (uint)PropertyID.Player5Score: {
                    int previousValue = _player5Score;
                    
                    _player5Score = (int)stream.ReadVarint32();
                    
                    if (!player5ScoreExistsInChangeCache && _player5Score != previousValue)
                        FirePlayer5ScoreDidChange(_player5Score);
                    break;
                }
                default:
                    stream.SkipProperty();
                    break;
            }
        }
    }
}
/* ----- End Normal Autogenerated Code ----- */
