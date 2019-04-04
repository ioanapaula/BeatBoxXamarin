using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BeatBoxXamarin.ViewModels;
using GalaSoft.MvvmLight.Helpers;

namespace BeatBoxXamarin.Droid.Fragments
{
    public class BeatBoxFragment : Fragment
    {
        private RecyclerView _soundRecyclerView;
        private BeatBox _beatBox;

        public static BeatBoxFragment NewInstance()
        {
            return new BeatBoxFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;

            _beatBox = new BeatBox(Activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_beat_box, container, false);
            _soundRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _soundRecyclerView.SetLayoutManager(new GridLayoutManager(container.Context, 3));
            _soundRecyclerView.SetAdapter(new SoundAdapter(_beatBox.Sounds, _beatBox));

            return view;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            _beatBox.Release();
        }

        private class SoundAdapter : RecyclerView.Adapter
        {
            private List<Sound> _sounds;
            private IBeatBox _beatBox;
             
            public SoundAdapter(List<Sound> sounds, IBeatBox beatBox)
            {
                _sounds = sounds;
                _beatBox = beatBox;
            }

            public override int ItemCount => _sounds.Count;

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                ((SoundHolder)holder).Bind(_sounds[position]);
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                var inflater = LayoutInflater.From(parent.Context);

                return new SoundHolder(_beatBox, inflater, parent);
            }
        }

        private class SoundHolder : RecyclerView.ViewHolder
        {
            private List<Binding> _bindings = new List<Binding>();
            private SoundViewModel _viewModel;
            private IBeatBox _beatBox;
            private Button _button;

            public SoundHolder(IBeatBox beatBox, LayoutInflater inflater, ViewGroup parent) : base(inflater.Inflate(Resource.Layout.list_item_sound, parent, false))
            {
                ItemView.ViewAttachedToWindow += ViewAttachedToWindow;
                ItemView.ViewDetachedFromWindow += ViewDetachedFromWindow;

                _beatBox = beatBox;
                _viewModel = new SoundViewModel(_beatBox);
                _button = ItemView.FindViewById<Button>(Resource.Id.sound_item_button);
                _button.SetCommand(_viewModel.ClickedCommand);
            }

            public void Bind(Sound sound)
            {
                _viewModel.Sound = sound;
                Bind();
            }

            private void Bind()
            {
                Unbind();

                _bindings.Add(this.SetBinding(
                    () => _viewModel.Title,
                    () => _button.Text));
            }

            private void Unbind()
            {
                _bindings.ForEach(element =>
                {
                    element.Detach();
                });

                _bindings.Clear();
            }

            private void ViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e)
            {
                Unbind();
            }

            private void ViewAttachedToWindow(object sender, View.ViewAttachedToWindowEventArgs e)
            {
                Bind();
            }
        }
    }
}
