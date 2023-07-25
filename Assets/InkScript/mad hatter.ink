Hello? # speaker: Alice
*Who are you? Are you the rabbit who led me down here? # speaker: Alice
	She thinks all rabbits are the same! Shame, shame. # speaker: March Hare #voice:HareMain1
*Where am I? # speaker: Alice 
    It’s not very polite not to introduce yourself.  # speaker: Mad Hatter
	** It’s not very polite not to answer my question. # speaker: Alice
		Not polite! Not polite, she says! # speaker: March Hare #voice:HareMain2
    ** Who are you, then? # speaker: Alice
- It’s not very polite of you not to remember us. # speaker: Mad Hatter
Have we met? # speaker: Alice
How should I know that? # speaker: Mad Hatter
You told me I should remember you! Shouldn’t you at least know if we’ve met? # speaker: Alice
You didn't! Why should I? # speaker: Mad Hatter
-> tellMe

===tellMe===
* This is going in circles. Who are you? # speaker: Alice
	Shouldn't you ask where it is you meet the people you are meeting? So rude without a greeting. I am the Hatter. # speaker: Mad Hatter
	** Well, it’s nice to meet you, Mr. Hatter. I am Alice. # speaker: Alice
	It’s not all that nice to meet you, Alice. You seem like a rather rude child. # speaker: March Hare #voice:HareMain3
	That's not very kind! I've done nothing to you! # speaker: Alice
	It’s not very polite of you to lie either! You’ve asked me many questions, as if you didn’t do this very thing! # speaker: Mad Hatter
	-> Suspects
	** The Mad Hatter then! How curious! # speaker: Alice
	It’s rude to call someone names. How would you feel if I called you Mad Alice? # speaker: Mad Hatter
	That's not very polite! # speaker: Alice
    Mad Alice, too concerned with politeness to be polite! No room! No room for you to sit. # speaker: March Hare #voice:HareMain4
    How do you know my name? # speaker: Alice
	I should know the people who have done me wrong! Only a child lacking such manners would throw me out of wonderland! # speaker: Mad Hatter

	-> Suspects
* Would you please just tell me where I am? # speaker: Alice
	Shouldn't the knower know the things asked by the asker? You ought to know the things that you have done! # speaker: Mad Hatter
	-> Suspects
	
=== Suspects ===
But I haven't done anything! # speaker: Alice
Well, if YOU haven’t done anything, then I suppose our Queen of Hearts may know the cards in the deck! How absurd… and you haven’t even sat for tea! # speaker: Mad Hatter
* Where is the Queen of Hearts? # speaker: Alice
	Forwards, I imagine! Never backwards, unless backwards was your forwards, but then, you’d have gone about the whole thing all wrong. And its quite wrong to be wrong when you haven't even sat for tea! # speaker: Mad Hatter
* I wasn’t invited to sit. # speaker: Alice
	It’s quite rude to stand while others sit. # speaker: March Hare
- There isn't time for tea! I must find the queen! # speaker: Alice
Then I suppose you must leave this room. But always on a different path than before, lest your destination remain in befuddlement! Inquire with me again if the doors give you trouble. # speaker: Mad Hatter
-> DONE
