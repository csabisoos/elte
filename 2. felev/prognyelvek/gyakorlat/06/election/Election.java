package election;

public class Election {
    private int[] voteCounts;

    public Election() {

    }

    public void addVote(election.candidate.Candidate candidate) {

    }

    public void addVotes(election.candidate.Candidate candidate, int x) {

    }

    private int getCandidateCountWithMoreVotesThan(int x) {
        return 0;
    }

    public election.candidate.Candidate[] getCandidatesWithMoreVotesThan(int x) {
        return new election.candidate.Candidate[0];
    }

    public election.candidate.Candidate getWinner() {
        return election.candidate.Candidate.JACK;
    }

    private int getWinningIdx() {
        return 0;
    }
}