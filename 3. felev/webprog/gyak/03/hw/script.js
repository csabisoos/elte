const bands = [
  {
    key: "gnr",
    name: "Guns N' Roses",
    origin: "USA",
    genre: "Hard Rock",
    founded: 1985,
    songs: [
      { title: "Welcome to the Jungle", year: 1987 },
      { title: "Sweet Child o' Mine", year: 1987 },
      { title: "November Rain", year: 1991 },
    ],
  },
  {
    key: "queen",
    name: "Queen",
    origin: "UK",
    genre: "Rock",
    founded: 1970,
    songs: [
      { title: "Bohemian Rhapsody", year: 1975 },
      { title: "We Will Rock You", year: 1977 },
    ],
  },
  {
    key: "zeppelin",
    name: "Led Zeppelin",
    origin: "UK",
    genre: "Hard Rock",
    founded: 1968,
    songs: [{ title: "Stairway to Heaven", year: 1971 }],
  },
  {
    key: "acdc",
    name: "AC/DC",
    origin: "Australia",
    genre: "Hard Rock",
    founded: 1973,
    songs: [{ title: "Back in Black", year: 1980 }],
  },
];

const bandsContainer = document.getElementById('bands');

function renderBands() {
  bandsContainer.innerHTML = '';

  bands.forEach(band => {
    const li = document.createElement('li');
    li.dataset.origin = band.origin;
    li.dataset.genre = band.genre;
    li.dataset.founded = band.founded;
    li.dataset.key = band.key;

    const h2 = document.createElement('h2');
    h2.className = 'band-name';
    h2.textContent = band.name;
    h2.tabIndex = 0;
    li.appendChild(h2);

    const meta = document.createElement('div');
    meta.className = 'meta';
    meta.innerHTML = `
      <span>Származás: ${band.origin}</span>
      <span>Stílus: ${band.genre}</span>
      <span>Alapítva: ${band.founded}</span>
    `;
    li.appendChild(meta);

    const ulSongs = document.createElement('ul');
    ulSongs.className = 'songs';

    if (!band.songs.length) {
      const empty = document.createElement('div');
      empty.className = 'empty';
      empty.textContent = 'Nincs dal.';
      ulSongs.appendChild(empty);
    } else {
      band.songs.forEach(song => {
        const sLi = document.createElement('li');
        sLi.dataset.year = song.year;
        sLi.dataset.title = song.title;

        const textNode = document.createTextNode(song.title + ' ');
        sLi.appendChild(textNode);

        const delBtn = document.createElement('button');
        delBtn.className = 'delete';
        delBtn.type = 'button';
        delBtn.setAttribute('aria-label', `Törlés: ${song.title}`);
        delBtn.textContent = '❌';
        sLi.appendChild(delBtn);

        ulSongs.appendChild(sLi);
      });
    }

    li.appendChild(ulSongs);
    bandsContainer.appendChild(li);
  });
}

renderBands();

bandsContainer.addEventListener('click', (e) => {
  const target = e.target;

  if (target.matches('button.delete')) {
    const songLi = target.closest('.songs li');
    if (!songLi) return;

    if (songLi.classList.contains('favorite')) {
      songLi.classList.remove('favorite');
    }

    songLi.classList.add('fade-out');
    songLi.addEventListener('animationend', () => {
      const songsUl = songLi.parentElement;
      songLi.remove();

      if (![...songsUl.children].some(el => el.tagName === 'LI')) {
        const empty = document.createElement('div');
        empty.className = 'empty';
        empty.textContent = 'Nincs dal.';
        songsUl.appendChild(empty);
      }
    }, { once: true });

    return;
  }

  if (target.matches('h2.band-name')) {
    const bandLi = target.closest('li[data-key]');
    if (!bandLi) return;

    [...bandsContainer.children].forEach(li => li.classList.remove('selected'));
    bandLi.classList.add('selected');
    return;
  }

  const songLi = target.closest('.songs li');
  if (songLi && !target.matches('button.delete')) {
    bandsContainer.querySelectorAll('.songs li.favorite').forEach(li => li.classList.remove('favorite'));
    songLi.classList.add('favorite');
  }
});

bandsContainer.addEventListener('keydown', (e) => {
  if (e.target.matches('h2.band-name') && (e.key === 'Enter' || e.key === ' ')) {
    e.preventDefault();
    e.target.click();
  }
});